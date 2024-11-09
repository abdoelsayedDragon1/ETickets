using ETickets.Data;
using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using ETickets.utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    [Authorize(Roles =$"{SD.adminRole}")]
    public class CategoryController : Controller
    {
        

        ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var Category = categoryRepository.Get();
            return View(model: Category);
        }

        public IActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {

                categoryRepository.Create(category);
                categoryRepository.commit();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public ActionResult Edit(int CategoryId)
        {
            var category = categoryRepository.GetOne(expression: e=>e.Id == CategoryId);
            //if (category != null)
                return View(model: category);
   
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
               categoryRepository.Edit(category);
                categoryRepository.commit();
                return RedirectToAction(nameof(Index));
            }
            return View(model: category);
        }

        public IActionResult Delete(int categoryId)
        {
            var Category = categoryRepository.GetOne(expression:e =>e.Id == categoryId);
            if(Category == null)
            {
                return View("Error");
            }
            categoryRepository.Delete(Category);
            categoryRepository.commit();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Search(string searchTerm)
        {
            var Category = categoryRepository.Get(expression: m => m.Name.Contains(searchTerm));

            return View("Index", Category);
        }

    }

   
}
