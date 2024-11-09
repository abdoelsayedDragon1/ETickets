using ETickets.Data;
using ETickets.Models;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ETickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository actorRepository;

        //ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActorController(IActorRepository actorRepository)
        {
            this.actorRepository = actorRepository;
        }
        public IActionResult Index()
        {
            var actor = actorRepository.Get();
            return View( model: actor);
        }

        public IActionResult Details(int Id)
        {
            var actor = actorRepository.GetOne([ a => a.ActorMovies], expression: a => a.Id == Id );

            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }



    }
}
