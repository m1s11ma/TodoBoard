using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBoardCore.Data.Entities;
using TodoBoardCore.Data.Interfaces;

namespace TodoBoardInfrastructure.DataAccess.Repositories.TodoItems
{
    public sealed class TodoItemCommentRepository : Repository<TodoItemComment>, ITodoItemCommentRepository
    {
        public TodoItemCommentRepository(ApplicationDbContext db) : base(db) { }
    }
}
