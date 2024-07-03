using Bogus;
using SalesPlatform.Infrastructure;
using SalesPlatform.Models;

namespace SalesPlatform.Seeders
{
    public class ShippingDetailsSeeder(AppDbContext context): ISeeder
    {
        public void seed(int count = 5)
        {
            if (context.ShippingDetails.Any())
            {
                return;
            }

            var faker = new Faker<ShippingDetails>()
                    .RuleFor(s => s.address, f => f.Address.StreetAddress())
                    .RuleFor(s => s.city, f => f.Address.City())
                    .RuleFor(s => s.state, f => f.Address.State())
                    .RuleFor(s => s.country, f => f.Address.Country())
                    .RuleFor(s => s.zipCode, f => f.Address.ZipCode());
            
            context.ShippingDetails.AddRange(faker.Generate(count));
            context.SaveChanges();
        }
    }
}