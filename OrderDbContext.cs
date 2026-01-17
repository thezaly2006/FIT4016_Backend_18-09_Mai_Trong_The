using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Models;
using System;

namespace OrderManagementApp.Data;

public class OrderDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Product entity
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Sku).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(e => e.StockQuantity).IsRequired();
            entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.Sku).IsUnique();
        });

        // Configure Order entity
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.OrderNumber).IsRequired().HasMaxLength(255);
            entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.CustomerEmail).IsRequired();
            entity.Property(e => e.Quantity).IsRequired();
            entity.HasIndex(e => e.OrderNumber).IsUnique();
            entity.HasIndex(e => e.CustomerEmail).IsUnique();
            entity.HasOne(e => e.Product)
                  .WithMany(p => p.Orders)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // -----------------------
        // SEEDING PRODUCTS (35 bản ghi)
        // -----------------------
        var random = new Random(42);
        var categories = new[] { "Electronics", "Accessories", "Audio", "Storage", "Networking", "Wearables", "Gaming" };
        var products = new List<Product>();
        var now = new DateTime(2026, 1, 17);

        string[] productNames = new[]
        {
            "Laptop Dell XPS 13", "Wireless Mouse", "Mechanical Keyboard", "27-inch Monitor",
            "USB-C Hub", "Gaming Headset", "External SSD 1TB", "Webcam HD",
            "Bluetooth Speaker", "Graphics Tablet", "Router WiFi 6", "Smartphone Case",
            "Power Bank 20000mAh", "VR Headset", "Wireless Earbuds", "Smart Watch",
            "Tablet iPad Pro", "Portable Charger", "Noise Cancelling Headphones", "4K Webcam",
            "Wireless Keyboard", "Gaming Mouse", "SSD 2TB", "Bluetooth Adapter",
            "Smart Home Hub", "Fitness Tracker", "Drone Camera", "E-Reader",
            "Streaming Microphone", "Portable Projector", "Dash Cam", "Wireless Router",
            "Smart Bulb", "Robot Vacuum", "Electric Scooter"
        };

        for (int i = 1; i <= 35; i++)
        {
            products.Add(new Product
            {
                Id = i,
                Name = productNames[i - 1],
                Sku = $"SKU-{1000 + i}",
                Description = $"High-quality {productNames[i - 1].ToLower()}",
                Price = (decimal)(10 + random.Next(1, 300)),
                StockQuantity = random.Next(20, 300),
                Category = categories[random.Next(categories.Length)],
                CreatedAt = now,
                UpdatedAt = now
            });
        }
        modelBuilder.Entity<Product>().HasData(products);

        // -----------------------
        // SEEDING ORDERS (35 bản ghi)
        // -----------------------
        var orders = new List<Order>();
        var baseDate = now.AddMonths(-1);

        for (int i = 1; i <= 35; i++)
        {
            var randomProduct = products[random.Next(0, products.Count)];
            var orderDate = baseDate.AddDays(random.Next(0, 30));
            var hasDelivery = random.Next(0, 2) == 0;
            var deliveryDate = hasDelivery ? orderDate.AddDays(random.Next(1, 7)) : (DateTime?)null;

            orders.Add(new Order
            {
                Id = i,
                ProductId = randomProduct.Id,
                OrderNumber = $"ORD-{orderDate:yyyyMMdd}-{i:D4}",
                CustomerName = $"Customer {i}",
                CustomerEmail = $"customer{i}@example.com",
                Quantity = random.Next(1, 10),
                OrderDate = orderDate,
                DeliveryDate = deliveryDate,
                CreatedAt = orderDate,
                UpdatedAt = now
            });
        }
        modelBuilder.Entity<Order>().HasData(orders);
    }
}
