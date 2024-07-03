using Bogus;
using SalesPlatform.Infrastructure;
using SalesPlatform.Models;

namespace SalesPlatform.Seeders
{
    public class OrderSeeder(AppDbContext context) : ISeeder
    {
        public void seed(int count = 5)
        {
            if (context.Order.Any())
            {
                return;
            }

            var faker = new Faker<Order>()
                    .RuleFor(o => o.status, f => f.PickRandom<OrderStatus>())
                    .RuleFor(o => o.customerId, context.Customer.First().id)
                    .RuleFor(o => o.storeId, context.Stores.First().id);
                
            context.AddRange(faker.Generate(count));
            context.SaveChanges();
        }
    }
}