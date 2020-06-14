using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ManageUsersApi.Models
{
    public static class PrepDB
    {
        public static void prepDataBase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                seedData(serviceScope.ServiceProvider.GetService<ManageUsersContext>());
            }
        }
        private static void seedData(ManageUsersContext context)
        {
            System.Console.WriteLine("Applying Migrations..");
            context.Database.Migrate();

        }
    }
}