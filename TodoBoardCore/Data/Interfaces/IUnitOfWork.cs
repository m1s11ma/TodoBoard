namespace TodoBoardCore.Data.Interfaces
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}
