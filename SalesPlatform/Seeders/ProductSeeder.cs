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
                    var minPrice = 10.0m; // Adjust minimum price as needed
                    var maxPrice = 100.0m; // Adjust maximum price as needed
                    var randomPrice = (decimal)(f.Random.Double()) * (maxPrice - minPrice) + minPrice;
                    return Math.Round(randomPrice, 2); // Round to 2 decimal places (cents)
                })
                .RuleFor(p => p.storeId, context.Stores.Find().id)
                .RuleFor(p => p.isDraft, f => f.Random.Bool())
                .RuleFor(p => p.stock, f => f.Random.Int(min: 0, max: 10000));
            
            context.Products.AddRange(faker.Generate(count));
            context.SaveChanges();
        }
    }
}