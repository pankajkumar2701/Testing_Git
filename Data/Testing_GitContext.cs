using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Testing_Git.Model;
using System;

namespace Testing_Git.Data
{
    public class Testing_GitContext : DbContext
    {
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-GFUVFUP;Initial Catalog=Testing_Git;Persist Security Info=True;user id=pankazz;password=123456;Integrated Security=true;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(a => a.CustomerId);
            modelBuilder.Entity<Order>().HasKey(a => a.OrderID);
            modelBuilder.Entity<OrderLine>().HasKey(a => a.OrderLineId);
            modelBuilder.Entity<Product>().HasKey(a => a.ProductId);
            modelBuilder.Entity<OrderStatus>().HasKey(a => a.OrderStatusId);
            modelBuilder.Entity<Country>().HasKey(a => a.CountryId);
            modelBuilder.Entity<Sales>().HasKey(a => a.SalesId);
            modelBuilder.Entity<OrderStatus2>().HasKey(a => a.OrderStatusId);
            modelBuilder.Entity<Product1>().HasKey(a => a.ProductId);
            modelBuilder.Entity<OrderStatus1>().HasKey(a => a.OrderStatusId);
            modelBuilder.Entity<Country1>().HasKey(a => a.CountryId);
            modelBuilder.Entity<Sales1>().HasKey(a => a.SalesId);
            modelBuilder.Entity<Customer1>().HasKey(a => a.CustomerId);
            modelBuilder.Entity<Order1>().HasKey(a => a.OrderID);
            modelBuilder.Entity<OrderLine1>().HasKey(a => a.OrderLineId);
            modelBuilder.Entity<Order11>().HasKey(a => a.OrderID);
            modelBuilder.Entity<OrderLine11>().HasKey(a => a.OrderLineId);
            modelBuilder.Entity<Sales2>().HasKey(a => a.SalesId);
            modelBuilder.Entity<OrderStatus3>().HasKey(a => a.OrderStatusId);
            modelBuilder.Entity<Product11>().HasKey(a => a.ProductId);
            modelBuilder.Entity<Employee>().HasKey(a => a.EmployeeId);
            modelBuilder.Entity<Employee1>().HasKey(a => a.EmployeeId1);
            modelBuilder.Entity<Product13>().HasKey(a => a.ProductId);
            modelBuilder.Entity<Employee3>().HasKey(a => a.EmployeeId);
            modelBuilder.Entity<Order10>().HasKey(a => a.OrderID);
            modelBuilder.Entity<OrderLine10>().HasKey(a => a.OrderLineId);
            modelBuilder.Entity<Product10>().HasKey(a => a.ProductId);
            modelBuilder.Entity<Order15>().HasKey(a => a.OrderID);
            modelBuilder.Entity<OrderLine15>().HasKey(a => a.OrderLineId);
            modelBuilder.Entity<Product15>().HasKey(a => a.ProductId);
            modelBuilder.Entity<Order>().HasOne(a => a.Customer).WithMany(b => b.Orders).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Order>().HasOne(a => a.OrderStatus).WithMany(b => b.Orders).HasForeignKey(c => c.OrderStatusId);
            modelBuilder.Entity<OrderLine>().HasOne(a => a.Order).WithMany(b => b.OrderLines).HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderLine>().HasOne(a => a.Product).WithMany(b => b.OrderLines).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Sales>().HasOne(a => a.Product).WithMany(b => b.Saless).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Sales1>().HasOne(a => a.Product).WithMany(b => b.Sales1s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Order1>().HasOne(a => a.Customer).WithMany(b => b.Order1s).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Order1>().HasOne(a => a.OrderStatus).WithMany(b => b.Order1s).HasForeignKey(c => c.OrderStatusId);
            modelBuilder.Entity<OrderLine1>().HasOne(a => a.Order).WithMany(b => b.OrderLine1s).HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderLine1>().HasOne(a => a.Product).WithMany(b => b.OrderLine1s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Order11>().HasOne(a => a.Customer).WithMany(b => b.Order11s).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Order11>().HasOne(a => a.OrderStatus).WithMany(b => b.Order11s).HasForeignKey(c => c.OrderStatusId);
            modelBuilder.Entity<OrderLine11>().HasOne(a => a.Order).WithMany(b => b.OrderLine11s).HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderLine11>().HasOne(a => a.Product).WithMany(b => b.OrderLine11s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Sales2>().HasOne(a => a.Product).WithMany(b => b.Sales2s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Order10>().HasOne(a => a.Customer).WithMany(b => b.Order10s).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Order10>().HasOne(a => a.OrderStatus).WithMany(b => b.Order10s).HasForeignKey(c => c.OrderStatusId);
            modelBuilder.Entity<OrderLine10>().HasOne(a => a.Order).WithMany(b => b.OrderLine10s).HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderLine10>().HasOne(a => a.Product).WithMany(b => b.OrderLine10s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Order15>().HasOne(a => a.Customer).WithMany(b => b.Order15s).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Order15>().HasOne(a => a.OrderStatus).WithMany(b => b.Order15s).HasForeignKey(c => c.OrderStatusId);
            modelBuilder.Entity<OrderLine15>().HasOne(a => a.Order).WithMany(b => b.OrderLine15s).HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderLine15>().HasOne(a => a.Product).WithMany(b => b.OrderLine15s).HasForeignKey(c => c.ProductId);
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<OrderStatus2> OrderStatus2 { get; set; }
        public DbSet<Product1> Product1 { get; set; }
        public DbSet<OrderStatus1> OrderStatus1 { get; set; }
        public DbSet<Country1> Country1 { get; set; }
        public DbSet<Sales1> Sales1 { get; set; }
        public DbSet<Customer1> Customer1 { get; set; }
        public DbSet<Order1> Order1 { get; set; }
        public DbSet<OrderLine1> OrderLine1 { get; set; }
        public DbSet<Order11> Order11 { get; set; }
        public DbSet<OrderLine11> OrderLine11 { get; set; }
        public DbSet<Sales2> Sales2 { get; set; }
        public DbSet<OrderStatus3> OrderStatus3 { get; set; }
        public DbSet<Product11> Product11 { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Employee1> Employee1 { get; set; }
        public DbSet<Product13> Product13 { get; set; }
        public DbSet<Employee3> Employee3 { get; set; }
        public DbSet<Order10> Order10 { get; set; }
        public DbSet<OrderLine10> OrderLine10 { get; set; }
        public DbSet<Product10> Product10 { get; set; }
        public DbSet<Order15> Order15 { get; set; }
        public DbSet<OrderLine15> OrderLine15 { get; set; }
        public DbSet<Product15> Product15 { get; set; }
    }
}