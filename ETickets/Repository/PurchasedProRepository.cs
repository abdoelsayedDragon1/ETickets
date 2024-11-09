using ETickets.Data;
using ETickets.Models;
using ETickets.Repository.IRepository;

namespace ETickets.Repository
{
    public class PurchasedProRepository : Repository<PurchasedProduct>, IPurchasedProRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PurchasedProRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
