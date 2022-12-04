﻿using Microsoft.EntityFrameworkCore;

namespace RoutesREST.Models
{
    public class SeedData
    {
        public static void EnsureCreated(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }

        public static void EnsureIdentityCreated(IApplicationBuilder app)
        {

        }
    }
}