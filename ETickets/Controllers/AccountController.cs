using ETickets.Models;
using ETickets.utility;
using ETickets.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ETickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
       // private readonly IEmailSender emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            //this.emailSender = emailSender;
        }


        public async Task<IActionResult> Register()
        {
            if(roleManager.Roles.IsNullOrEmpty())
            {
                {
                   await roleManager.CreateAsync( new(SD.adminRole));
                   await roleManager.CreateAsync(new(SD.companyRole));
                   await roleManager.CreateAsync(new(SD.customerRole));
                }

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ApplicationUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    UserName = userVM.Name,
                    Email = userVM.Email,
                    Address = userVM.Address
                };
               var result = await UserManager.CreateAsync(applicationUser, userVM.Password);
                

                if (result.Succeeded)
                {

                    await UserManager.AddToRoleAsync(applicationUser, SD.customerRole);
                    await signInManager.SignInAsync(applicationUser, false);
                   // await emailSender.SendEmailAsync(applicationUser.Email, "confirmation", "bla bla");
                    return RedirectToAction("Index", "Movie");
                }
                ModelState.AddModelError("Password", "Invalid Password");

            }
            return View(userVM);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM userVM)
        {
            if (ModelState.IsValid)
            {
               var userDb =  await UserManager.FindByNameAsync(userVM.UserName);
                if(userDb != null)
                {
                   var finalresult = await UserManager.CheckPasswordAsync(userDb, userVM.Password);
                    if(finalresult)
                    {
                       await signInManager.SignInAsync(userDb, userVM.RemeberMe);
                        return RedirectToAction("Index", "Movie");

                    }
                    else
                    {
                        ModelState.AddModelError("password", "Indalid Password");
                    }

                }
                else
                {
                    ModelState.AddModelError("UserName", "Indalid UserName");

                }

            }
            return View(userVM);
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
