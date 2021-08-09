using FileManagement.Application.Contracts;
using FileManagement.Application.Contracts.Persistence;
using FileManagement.Persistence.FileOperations;
using FileManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<FileManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FileManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IFileStorageProvider, FileSystemStorageProvider>();

            return services;
        }
    }
}