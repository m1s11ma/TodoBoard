using EntityFramework.Exceptions.Common;
using TodoBoardCore.Data.Interfaces;
using TodoBoardCore.Exceptions;

namespace TodoBoardInfrastructure.DataAccess.UOW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
            }
            catch(UniqueConstraintException)
            {
                throw new ValueAlreadyExistException();
            }
            
        }
    }
}
