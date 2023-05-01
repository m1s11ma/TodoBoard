using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBoardCore.Data.Entities;
using TodoBoardCore.Data.ValueObjects;

namespace TodoBoardInfrastructure.DataAccess.Specifications.TodoItems
{
    public class TodoItemByTitleSpecification : Specification<TodoItem>
    {
        public TodoItemByTitleSpecification(string title, TodoItemCategory category) : base(item => item.Title == title && item.Category == category) { }
    }
}
