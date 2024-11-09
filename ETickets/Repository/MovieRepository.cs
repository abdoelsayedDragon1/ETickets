using ETickets.Data;
using ETickets.Models;
using ETickets.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public Movie GetMovieWithDetails(int id)
        {
            return dbContext.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .FirstOrDefault(m => m.Id == id);
        }

        public List<Actor> GetActorsByMovieId(int movieId)
        {
            return dbContext.ActorMovies
                .Where(e => e.MoviesId == movieId)
                .Select(actor => dbContext.Actors.First(a => a.Id == actor.ActorsId))
                .ToList();
        }
    }
}
