using Microsoft.EntityFrameworkCore;
using TodoBoardCore.Data.Entities;
using TodoBoardCore.Data.Interfaces;
using TodoBoardCore.Data.ValueObjects;
using TodoBoardCore.Exceptions;
using TodoBoardCore.Exceptions.TodoItems;
using TodoBoardInfrastructure.DataAccess.Specifications;
using TodoBoardInfrastructure.DataAccess.Specifications.TodoItems;

namespace TodoBoardInfrastructure.DataAccess.Repositories.TodoItems
{
    public sealed class TodoItemRepository : Repository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(ApplicationDbContext db) : base(db) { }
        public Task<List<TodoItem>> GetAllAsync()
        {
            return _db.TodoItems.ToListAsync();
        }

        public Task<List<TodoItem>> GetAllWithCommentsAsync()
        {
            return _db.TodoItems.Include(item => item.Comments).ToListAsync();
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            var query = ApplySpecification(new TodoItemByIdSpecification(id));
            var item = await query.SingleOrDefaultAsync();
            if (item == null) throw new EntityNotFoundException<TodoItem>(id);
            return item;
        }

        public async Task<TodoItem> GetByIdWithCommentsAsync(int id)
        {
            var query = ApplySpecification(new TodoItemByIdWithCommentsSpecification(id));
            var item = await query.SingleOrDefaultAsync();
            if (item == null) throw new EntityNotFoundException<TodoItem>(id);
            return item;
        }

        public async Task<TodoItem> GetByTitleAsync(string title, string category)
        {
            var query = ApplySpecification(new TodoItemByTitleSpecification(title, TodoItemCategory.From(category)));
            var item = await query.SingleOrDefaultAsync();
            if (item == null) throw new TodoItemNotFoundException(title);
            return item;
        }

        public async Task<TodoItem> GetByTitleWithCommentsAsync(string title, string category)
        {
            var query = ApplySpecification(new TodoItemByTitleWithCommentsSpecification(title, TodoItemCategory.From(category)));
            var item = await query.SingleOrDefaultAsync();
            if(item == null) throw new TodoItemNotFoundException(title);
            return item;
        }

        public async Task<bool> IsExisteAsync(int id)
        {
            try
            {
                var item = await GetByIdAsync(id);
                return true;
            }
            catch (EntityNotFoundException<TodoItem>)
            {
                return false;
            }
        }

        private IQueryable<TodoItem> ApplySpecification(Specification<TodoItem> specification)
        {
            return SpecificationApplyer.GetQuery(_db.Set<TodoItem>(), specification);
        }
    }
}
