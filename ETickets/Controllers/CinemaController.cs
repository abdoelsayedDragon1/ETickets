using ETickets.Data;
using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ETickets.Controllers
{
    public class CinemaController : Controller
    {
        //ApplicationDbContext dbContext = new ApplicationDbContext();
        // CinemaRepository CinemaRepository = new CinemaRepository();
       
        private readonly ICinemaRepository cinemaRepository;

        public CinemaController(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }

        public IActionResult Index()
        {
            var Cinema = cinemaRepository.Get();
            return View(model: Cinema);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Cinema cinema = new Cinema();
            return View( new Cinema());
        }

        public IActionResult Create(Cinema cinema, IFormFile cinemalogo)
        {
            ModelState.Remove("CinemaLogo");
            if (ModelState.IsValid)
            {
                if (cinemalogo != null && cinemalogo.Length > 0)
                {


                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(cinemalogo.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Cinema", fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        cinemalogo.CopyTo(stream);
                    }

                    cinema.CinemaLogo = fileName;
                }

                cinemaRepository.Create(cinema);
                cinemaRepository.commit();

                return RedirectToAction(nameof(Index));

            }
            return View(cinema);


        }
        [HttpGet]
        public IActionResult Edit(int cinemaId)
        {
            var cinema = cinemaRepository.GetOne(expression: e => e.Id == cinemaId);
            if (cinema == null)
            {
                return NotFound();
            }
            return View(model: cinema);
        }
        [HttpPost]
        public IActionResult Edit(Cinema cinema, IFormFile cinemalogo)
        {
            var oldCinema = cinemaRepository.GetOne(expression: e => e.Id == cinema.Id);
            if (oldCinema == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                oldCinema.Name = cinema.Name;
                oldCinema.Description = cinema.Description;
                oldCinema.Address = cinema.Address;

                if (cinemalogo != null && cinemalogo.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(cinemalogo.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Cinema", fileName);

                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Cinema", oldCinema.CinemaLogo);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        cinemalogo.CopyTo(stream);
                    }

                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }

                    oldCinema.CinemaLogo = fileName; 
                }
                else
                {
                    oldCinema.CinemaLogo = oldCinema.CinemaLogo;
                }

                
                cinemaRepository.Edit(oldCinema);
                cinemaRepository.commit();

                return RedirectToAction(nameof(Index));
            }

            cinema.CinemaLogo = oldCinema.CinemaLogo;
            return View(cinema);
        }




        public IActionResult Delete(int cinemaId)
        {
            var cinema = cinemaRepository.GetOne( expression: e=>e.Id == cinemaId);
            cinemaRepository.Delete(cinema);
            cinemaRepository.commit();

            return RedirectToAction(nameof(Index));
        }



        private string? UploadImg(IFormFile cinemlogo)
        {
            if (cinemlogo.Length > 0)
            {
                var fileName = cinemlogo.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Cinema", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    cinemlogo.CopyTo(stream);
                }
                return cinemlogo.FileName;
            }
            return null;
        }

        public IActionResult Search(string searchTerm)
        {
            var cinemas = cinemaRepository.Get(expression: m => m.Name.Contains(searchTerm));

            return View("Index", cinemas);
        }
       

    }
}
