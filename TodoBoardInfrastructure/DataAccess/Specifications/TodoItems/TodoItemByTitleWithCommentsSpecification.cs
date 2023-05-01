using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBoardCore.Data.ValueObjects;

namespace TodoBoardInfrastructure.DataAccess.Specifications.TodoItems
{
    public class TodoItemByTitleWithCommentsSpecification : TodoItemByTitleSpecification
    {
        public TodoItemByTitleWithCommentsSpecification(string title, TodoItemCategory category) : base(title, category) 
        {
            AddInclude(item => item.Comments);
        }
    }
}
