using TodoBoardCore.Data.Common;

namespace TodoBoardCore.Data.Interfaces
{
    public interface IRepository<TEnt> where TEnt : BaseEntity
    {
        void Add(TEnt entity);
        TEnt Update(TEnt entity);
        TEnt Delete(TEnt entity);
    }
}
