using SalesPlatform.Infrastructure;
using SalesPlatform.Models;

namespace SalesPlatform.Seeders
{
    public class UserSeeder(AppDbContext context) : ISeeder
    {
        public void seed(int count = 1)
        {
            if (context.Users.Any())
            {
                return;
            }
            
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("123");

            User toInsertUser = new User { email = "s@s.dk", password = hashedPassword, store = null };
            context.Users.Add(toInsertUser);
            context.SaveChanges();
        }
    }
}