using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using ETickets.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Stripe.Checkout;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ETickets.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPurchasedProRepository purchasedProRepository;

        public CartController(ICartRepository cartRepository, UserManager<ApplicationUser> userManager, IPurchasedProRepository purchasedProRepository)
        {
            this.cartRepository = cartRepository;
            this.userManager = userManager;
            this.purchasedProRepository = purchasedProRepository;
        }

        public IActionResult AddToCart(int movieId, int count)
        {

            var appUser = userManager.GetUserId(User);
            if (appUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Cart cart = new Cart()
            {
                Count = count,
                MovieId = movieId,
                ApplicationUserId = appUser
            };

            var cartDB = cartRepository.GetOne(expression: e => e.MovieId == movieId && e.ApplicationUserId == appUser);

            if (cartDB == null)
                cartRepository.Create(cart);
            else
                cartDB.Count += count;

            cartRepository.commit();

            TempData["success"] = "Add Movie to cart successfully";
            return RedirectToAction("Index", "Movie");
        }

        public IActionResult Index()
        {
            var appUser = userManager.GetUserId(User);

            var shoppingcart = cartRepository.Get([e => e.Movie, e => e.ApplicationUser], e => e.ApplicationUserId == appUser);

            ViewBag.TotalPrice = shoppingcart.Sum(e => e.Movie.Price * e.Count);
            ViewBag.TotalItems = shoppingcart.Sum(e => e.Count); 

            return View(shoppingcart);
        }

        public IActionResult Increment(int movieId)
        {
            var appUser = userManager.GetUserId(User);
            var cartdb = cartRepository.GetOne(expression: e => e.MovieId == movieId && e.ApplicationUserId == appUser);
            if (cartdb != null)
            {
                cartdb.Count++;
            }
            cartRepository.commit();
            return RedirectToAction("Index");
        }

        public IActionResult Decrement(int movieId)
        {
            var appUser = userManager.GetUserId(User);
            var cartdb = cartRepository.GetOne(expression: e => e.MovieId == movieId && e.ApplicationUserId == appUser);
            if (cartdb != null)
            {
                cartdb.Count--;
                if (cartdb.Count == 0)
                {
                    cartRepository.Delete(cartdb);
                }
            }
            cartRepository.commit();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int movieId)
        {
            var appUser = userManager.GetUserId(User);
            var cartdb = cartRepository.GetOne(expression: e => e.MovieId == movieId && e.ApplicationUserId == appUser);
            if (cartdb != null)
            {
                cartRepository.Delete(cartdb);
            }
            cartRepository.commit();
            return RedirectToAction("Index");
        }

        public IActionResult Pay()
        {
            var appUserId = userManager.GetUserId(User);
            if (appUserId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartDBs = cartRepository.Get([ e => e.Movie ], expression: e => e.ApplicationUserId == appUserId);

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = $"{Request.Scheme}://{Request.Host}/Cart/PaymentSuccess",
                CancelUrl = $"{Request.Scheme}://{Request.Host}/Cart/Cancel"
            };

            foreach (var item in cartDBs)
            {
                var result = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "egp",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Movie.Name,
                            Description = item.Movie.Description,
                        },
                        UnitAmount = (long)item.Movie.Price * 100,
                    },
                    Quantity = item.Count,
                };
                options.LineItems.Add(result);
            }

            var service = new SessionService();
            var session = service.Create(options);

            return Redirect(session.Url);
        }

        public IActionResult PaymentSuccess()
        {
            var appUserId = userManager.GetUserId(User);
            if (appUserId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartDBs = cartRepository.Get([e => e.Movie, e => e.ApplicationUser], expression: e => e.ApplicationUserId == appUserId);
            var purchasedProducts = new List<PurchasedProduct>();

            foreach (var item in cartDBs)
            {
                var purchasedProduct = new PurchasedProduct
                {
                    ApplicationUserId = appUserId,
                    ApplicatinName = item.ApplicationUser.UserName,
                    MovieId = item.Movie.Id,
                    MovieName = item.Movie.Name,
                    MoviePrice = item.Movie.Price,
                    ProductPrice = item.Movie.Price * item.Count,
                    numOfTicets = item.Count,
                    PurchaseDate = DateTime.Now,
                    Movie = item.Movie,
                    applicationUser = null
                };

                purchasedProRepository.Create(purchasedProduct);
                purchasedProducts.Add(purchasedProduct);
            }
            purchasedProRepository.commit();

            foreach (var item in cartDBs)
            {
              cartRepository.Delete(item);
            }
            cartRepository.commit();

            return View("PurchasedProducts", purchasedProducts);
        }











    }


}
