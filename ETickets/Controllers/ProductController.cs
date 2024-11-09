using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class ProductController : Controller
    {
        private readonly IPurchasedProRepository purchasedProRepository;

        public ProductController(IPurchasedProRepository purchasedProRepository)
        {
            this.purchasedProRepository = purchasedProRepository;
        }
        public IActionResult Index()
        {
            var Product = purchasedProRepository.Get();
            return View(Product);
        }
    }
}
