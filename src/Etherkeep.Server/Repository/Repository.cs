using System.Linq;

namespace Etherkeep.Data.Repository
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TEntity GetById(TKey id)
        {
            return null;
        }

        public PagedResult<TEntity> GetPage(int pageNumber, int pageSize)
        {
            var page = new PagedResult<TEntity>();

            var entities = Enumerable.Empty<TEntity>();

            page.TotalCount = entities.Count();
            page.Items      = entities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return page;
        }

        public void Update(TEntity entity)
        {

        }

        public void Delete(TEntity entity)
        {

        }
    }
}
