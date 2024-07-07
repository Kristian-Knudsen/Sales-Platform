using Bogus;
using SalesPlatform.Infrastructure;
using SalesPlatform.Models;

namespace SalesPlatform.Seeders
{
    public class ProductSeeder(AppDbContext context) : ISeeder
    {
        public void seed(int count = 5)
        {
            if (context.Products.Any())
            {
                return;
            }

            var faker = new Faker<Product>()
                .RuleFor(p => p.name, f => f.Commerce.ProductName())
                .RuleFor(p => p.description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.price, f =>
                {
                    const decimal minPrice = 10.0m; // Adjust minimum price as needed
                    const decimal maxPrice = 100.0m; // Adjust maximum price as needed
                    decimal randomPrice = (decimal)(f.Random.Double()) * (maxPrice - minPrice) + minPrice;
                    return Math.Round(randomPrice, 2); // Round to 2 decimal places (cents)
                })
                .RuleFor(p => p.storeId, f => f.PickRandom(context.Stores.ToList()).id)
                .RuleFor(p => p.isDraft, f => f.Random.Bool())
                .RuleFor(p => p.stock, f => f.Random.Int(min: 0, max: 10000));
            
            context.Products.AddRange(faker.Generate(count));
            context.SaveChanges();
        }
    }
}