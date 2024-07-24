using Microsoft.EntityFrameworkCore;
using SalesPlatform.Models;

namespace SalesPlatform.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && (
                    e.State == EntityState.Modified
                ));

            foreach (var entity in entries)
            {
                ((BaseModel)entity.Entity).updatedAt = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.store)
                .WithMany(s => s.employees)
                .HasForeignKey(u => u.storeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.storeId, u.isOwner })
                .IsUnique();

            modelBuilder.Entity<Store>()
                .HasMany(s => s.products)
                .WithOne(p => p.store)
                .HasForeignKey(p => p.storeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.shippingDetails)
                .WithOne(sd => sd.customer)
                .HasForeignKey<ShippingDetails>(sd => sd.customerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.customer)
                .WithMany(c => c.orders)
                .HasForeignKey(o => o.customerId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.order)
                .WithMany(o => o.orderItems)
                .HasForeignKey(oi => oi.orderId);
            
            modelBuilder.Entity<CustomerInteraction>()
                .HasOne(i => i.customer)
                .WithMany()
                .HasForeignKey(i => i.customerId);

            modelBuilder.Entity<CustomerInteraction>()
                .HasOne(i => i.status)
                .WithMany()
                .HasForeignKey(i => i.customerInteractionStatusId); 
            modelBuilder.Entity<CustomerInteraction>()
                .HasOne(i => i.channel)
                .WithMany()
                .HasForeignKey(i => i.customerInteractionChannelId);  // Assuming you have a channelId property

            modelBuilder.Entity<CustomerInteractionMessage>()
                .HasOne(m => m.interaction)
                .WithMany()
                .HasForeignKey(m => m.interactionId); // Assuming you have an interactionId property

            // Define the primary key for the join table between Interaction and Message (optional)
            modelBuilder.Entity<CustomerInteractionMessage>()
                .HasKey(m => new { m.interactionId, m.id });
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
        public DbSet<CustomerInteraction> CustomerInteractions { get; set; }
        public DbSet<CustomerInteractionMessage> CustomerInteractionMessages { get; set; }
        public DbSet<CustomerInteractionChannel> CustomerInteractionChannels { get; set; }
        public DbSet<CustomerInteractionStatus> CustomerInteractionStatusses { get; set; }
    }
}
