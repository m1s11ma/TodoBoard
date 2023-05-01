using TodoBoardCore.Data.Common;
using TodoBoardCore.Data.Interfaces;

namespace TodoBoardInfrastructure.DataAccess.Repositories
{
    public abstract class Repository<TEnt> : IRepository<TEnt> where TEnt : BaseEntity
    {
        protected ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(TEnt entity)
        {
            _db.Set<TEnt>().Add(entity);
        }

        public TEnt Delete(TEnt entity)
        {
            _db.Set<TEnt>().Remove(entity);
            return entity;
        }

        public TEnt Update(TEnt entity)
        {
            _db.Set<TEnt>().Update(entity);
            return entity;
        }
    }
}
