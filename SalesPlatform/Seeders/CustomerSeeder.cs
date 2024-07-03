using SalesPlatform.Infrastructure;
using SalesPlatform.Models;
using Bogus;

namespace SalesPlatform.Seeders
{
    public class CustomerSeeder(AppDbContext context) : ISeeder
    {
        public void seed(int count = 5)
        {
            if (context.Customer.Any())
            {
                return;
            }

            var faker = new Faker<Customer>()
                    .RuleFor(c => c.firstName, f => f.Name.FirstName())
                    .RuleFor(c => c.lastName, f => f.Name.LastName())
                    .RuleFor(c => c.email, f => f.Internet.Email())
                    .RuleFor(c => c.shippingDetailsId, context.ShippingDetails.First().id);

            context.Customer.AddRange(faker.Generate(count));
            context.SaveChanges();
        }
    }
}