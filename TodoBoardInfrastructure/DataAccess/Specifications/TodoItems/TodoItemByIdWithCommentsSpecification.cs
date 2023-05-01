namespace TodoBoardInfrastructure.DataAccess.Specifications.TodoItems
{
    public class TodoItemByIdWithCommentsSpecification : TodoItemByIdSpecification
    {
        public TodoItemByIdWithCommentsSpecification(int id) : base(id)
        {
            AddInclude(item => item.Comments);
        }
    }
}
