using Bogus;
using SalesPlatform.Infrastructure;
using SalesPlatform.Models;

namespace SalesPlatform.Seeders
{
    public class OrderItemSeeder(AppDbContext context) : ISeeder
    {
        public void seed(int count = 5)
        {
            if (context.OrderItem.Any())
            {
                return;
            }

            var faker = new Faker<OrderItem>()
                .RuleFor(o => o.quantity, f => f.Random.Int(min: 1, max: 10))
                .RuleFor(o => o.productId, context.Products.First().id)
                .RuleFor(o => o.orderId, context.Order.First().id);
            
            context.OrderItem.AddRange(faker.Generate(count));
            context.SaveChanges();
        }
    }
}