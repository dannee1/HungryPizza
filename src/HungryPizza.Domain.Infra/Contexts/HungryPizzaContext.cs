using Microsoft.EntityFrameworkCore;
using HungryPizza.Domain.Entities;

namespace HungryPizza.Domain.Infra.Contexts
{
    public class HungryPizzaContext : DbContext
    {
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }
        public HungryPizzaContext(DbContextOptions<HungryPizzaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaFlavor>().HasKey(ps => ps.Id).HasName("PK_pizzaFlavorId");
            modelBuilder.Entity<PizzaFlavor>()
                .HasOne(ps => ps.Pizza)
                .WithMany(p => p.PizzaFlavors)
                .HasForeignKey(ps => ps.IdPizza);
            modelBuilder.Entity<PizzaFlavor>()
                .HasOne(ps => ps.Flavor)
                .WithMany(p => p.PizzaFlavors)
                .HasForeignKey(ps => ps.IdFlavor);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.IdUser);
                entity.HasMany(e => e.Pizzas)
                    .WithOne(e => e.Order);
                entity.HasKey(e => e.Id).HasName("PK_orderId");
                entity.Property(e => e.Idaddress);
                entity.Property(e => e.IdUser);
                entity.Property(e => e.OrderDateTime);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(e => e.Orders)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.IdUser);
                entity.HasMany(e => e.Addresses)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.IdUser);
                entity.HasKey(e => e.Id).HasName("PK_userId");
                entity.Property(e => e.Name).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.DDD).IsRequired().HasColumnType("varchar(2)");
                entity.Property(e => e.EmailLogin).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Password).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Phone).IsRequired().HasColumnType("varchar(9)");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_pizzaId");
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(8,2)");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(e => e.User)
                   .WithMany(c => c.Addresses)
                   .HasForeignKey(e => e.IdUser);
                entity.HasKey(e => e.Id).HasName("PK_addressId");
                entity.Property(e => e.Neighborhood).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.ZipCode).IsRequired().HasColumnType("varchar(8)");
                entity.Property(e => e.Complement).HasColumnType("varchar(20)");
                entity.Property(e => e.City).IsRequired().HasColumnType("varchar(50)");
                entity.Property(e => e.Number).IsRequired().HasColumnType("varchar(10)");
                entity.Property(e => e.AddressName).HasColumnName("AddressName").IsRequired().HasColumnType("varchar(80)");
                entity.Property(e => e.State).IsRequired().HasColumnType("varchar(2)");
            });

            modelBuilder.Entity<Flavor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_flavorId");
                entity.Property(e => e.Description).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(8,2)");
            });

            modelBuilder.Entity<Flavor>().HasData(
                new Flavor("3 Queijos", 50),
                new Flavor("Frango com requeijão ", (decimal)59.99),
                new Flavor("Mussarela ", (decimal)42.50),
                new Flavor("Calabresa ", (decimal)42.50),
                new Flavor("Pepperoni", 55),
                new Flavor("Portuguesa ", 45),
                new Flavor("Veggie ", (decimal)59.99));
        }
    }
}
