using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBoardCore.Data.Entities;

namespace TodoBoardInfrastructure.DataAccess.Specifications.TodoItems
{
    public class TodoItemByIdSpecification : Specification<TodoItem>
    {
        public TodoItemByIdSpecification(int id) : base(item => item.Id == id)
        {

        }

    }
}
