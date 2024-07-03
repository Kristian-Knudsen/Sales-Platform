using Bogus;
using SalesPlatform.Infrastructure;
using SalesPlatform.Models;

namespace SalesPlatform.Seeders
{
    public class StoreSeeder(AppDbContext context) : ISeeder
    {
        public void seed(int count = 5)
        {
            if (context.Stores.Any())
            {
                return;
            }

            var faker = new Faker<Store>()
                .RuleFor(s => s.name, f => f.Company.CompanyName());
            
            context.Stores.AddRange(faker.Generate(count));
            context.SaveChanges();
        }
    }
}