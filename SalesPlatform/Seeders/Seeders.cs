using SalesPlatform.Infrastructure;

namespace SalesPlatform.Seeders
{
    public class Seeders(AppDbContext context) : ISeeder
    {
        public void seed(int count = 1)
        {
            new UserSeeder(context).seed(1);
            new StoreSeeder(context).seed(2);
            new ShippingDetailsSeeder(context).seed(1);
            new CustomerSeeder(context).seed(1);
            new OrderSeeder(context).seed(5);
            new ProductSeeder(context).seed(10);
            new OrderItemSeeder(context).seed(10);
        }
    }
}