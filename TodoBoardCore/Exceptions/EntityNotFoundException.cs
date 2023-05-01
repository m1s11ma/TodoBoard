using TodoBoardCore.Data.Common;

namespace TodoBoardCore.Exceptions
{
    public class EntityNotFoundException<TEnt> : Exception
        where TEnt : BaseEntity
    {
        public EntityNotFoundException(int id) : base($"Entity {typeof(TEnt).Name} with Id {id} wasn't found") { }
    }
}
