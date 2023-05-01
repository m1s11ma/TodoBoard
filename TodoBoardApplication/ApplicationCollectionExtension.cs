using Microsoft.Extensions.DependencyInjection;
using TodoBoardApplication.AutoMapperProfiles;
using TodoBoardApplication.Services.TodoItems;
using TodoBoardCore.Services.TodoItems;

namespace TodoBoardApplication
{
    public static class ApplicationCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IAddCommentToTodoItemService, AddCommentToTodoItemService>();
            services.AddTransient<IAddTodoItemService, AddTodoItemService>();
            services.AddTransient<IGetAllTodoItemsService, GetAllTodoItemsService>();
            services.AddTransient<IGetTodoItemCommentsService, GetTodoItemCommentsService>();
            services.AddTransient<IGetTodoItemService, GetTodoItemService>();
            services.AddTransient<IDeleteTodoItemService, DeleteTodoItemService>();
            services.AddTransient<IUpdateTodoItemService, UpdateTodoItemService>();

            services.AddAutoMapper(typeof(TodoItemProfile));
            return services;
        }
    }
}
