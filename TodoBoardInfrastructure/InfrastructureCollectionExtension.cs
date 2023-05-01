using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBoardCore.Data.Interfaces;
using TodoBoardInfrastructure.DataAccess;
using TodoBoardInfrastructure.DataAccess.Repositories.TodoItems;
using TodoBoardInfrastructure.DataAccess.UOW;

namespace TodoBoardInfrastructure
{
    public static class InfrastructureCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(ApplicationDbContext))).UseExceptionProcessor();
            });
            services.AddTransient<ITodoItemRepository, TodoItemRepository>();
            services.AddTransient<ITodoItemCommentRepository, TodoItemCommentRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
