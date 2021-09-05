using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seeding
{
    public class MassageTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            await SeedTypes(dbContext.MassageTypes, "Regeneration", 20);
            await SeedTypes(dbContext.MassageTypes, "Relax", 30);
            await SeedTypes(dbContext.MassageTypes, "Special", 50);
        }
        private static async Task SeedTypes(DbSet<MassageType> massageTypes, string name, decimal price)
        {
            var newProfit = await massageTypes.FirstOrDefaultAsync();
            if (newProfit == null)
            {
                var result = await massageTypes.AddAsync(new MassageType() { Name = name, Price = price});

                if (result.Entity == null)
                {
                    throw new Exception(string.Join(Environment.NewLine, "Invalid operation."));
                }
            }
        }
    }
}
