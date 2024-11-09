

using System.Linq.Expressions;

namespace ETickets.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> Get(Expression<Func<T, object>>[]? Include = null, Expression<Func<T, bool>>? expression = null, bool tracked = true);


        T? GetOne(Expression<Func<T, object>>[]? includeProps = null, Expression<Func<T, bool>>? expression = null, bool tracked = true);

        void Create(T Entity);

        void Edit(T Entity);


        void Delete(T Entity);


        void commit();
    }
}
