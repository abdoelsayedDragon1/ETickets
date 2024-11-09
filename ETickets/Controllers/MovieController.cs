using ETickets.Data;
using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETickets.Controllers
{
    public class MovieController : Controller
    {

        private readonly IMovieRepository movieRepository;
        private readonly IActorMovieRepository actorMovieRepository;
        private readonly IActorRepository actorRepository;

        public MovieController(IMovieRepository movieRepository, IActorMovieRepository  actorMovieRepository, IActorRepository  actorRepository )
        {
            this.movieRepository = movieRepository;
            this.actorMovieRepository = actorMovieRepository;
            this.actorRepository = actorRepository;
        }



        public IActionResult Index(int pageNum = 1)
        {
            IEnumerable<Movie> movies = movieRepository.Get([m => m.Category, m => m.Cinema ]);

            int totalPages = (int)Math.Ceiling((double)movies.Count() / 6);

            if (pageNum < 1 || pageNum > totalPages)
            {
                return RedirectToAction("NotFound", "Home");
            }

            var pagedMovies = movies.Skip((pageNum - 1) * 6).Take(6).ToList();

            ViewBag.CurrentPage = pageNum;
            ViewBag.TotalPages = totalPages;
            return View(model: pagedMovies);

        }


        public IActionResult Details(int Id)
        {
            var movie = movieRepository.GetOne([m => m.Cinema, m => m.Category], expression: m => m.Id == Id);

            if (movie == null) return NotFound();

            var actorIds = actorMovieRepository
                .Get(expression: am => am.MoviesId == Id)
                .Select(am => am.ActorsId);

            var actors = actorRepository
                .Get(expression: a => actorIds.Contains(a.Id));

            ViewBag.actors = actors;
            return View(movie);
        }


        public IActionResult Search(string searchTerm)
        {
          var movies = movieRepository.Get([ c => c.Cinema, c => c.Category ], expression: m => m.Name.ToLower().Contains(searchTerm.ToLower()) ||
          m.Category.Name.ToLower().Contains(searchTerm.ToLower()) );

            return View("Index", movies);
        }






    }
}
