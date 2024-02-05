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
            modelBuilder.Entity<OrderStatus35>().HasKey(a => a.OrderStatusId);
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
            modelBuilder.Entity<Customer52>().HasKey(a => a.CustomerId);
            modelBuilder.Entity<Order74>().HasKey(a => a.OrderID);
            modelBuilder.Entity<OrderLine74>().HasKey(a => a.OrderLineId);
            modelBuilder.Entity<Product74>().HasKey(a => a.ProductId);
            modelBuilder.Entity<OrderStatus15>().HasKey(a => a.OrderStatusId);
            modelBuilder.Entity<Country55>().HasKey(a => a.CountryId);
            modelBuilder.Entity<Sales55>().HasKey(a => a.SalesId);
            modelBuilder.Entity<OrderStatus24>().HasKey(a => a.OrderStatusId);
            modelBuilder.Entity<Product18>().HasKey(a => a.ProductId);
            modelBuilder.Entity<OrderStatus17>().HasKey(a => a.OrderStatusId);
            modelBuilder.Entity<Country17>().HasKey(a => a.CountryId);
            modelBuilder.Entity<Sales17>().HasKey(a => a.SalesId);
            modelBuilder.Entity<Customer144>().HasKey(a => a.CustomerId);
            modelBuilder.Entity<Order114>().HasKey(a => a.OrderID);
            modelBuilder.Entity<OrderLine14>().HasKey(a => a.OrderLineId);
            modelBuilder.Entity<OrderLine114>().HasKey(a => a.OrderLineId);
            modelBuilder.Entity<Sales21>().HasKey(a => a.SalesId);
            modelBuilder.Entity<OrderStatus3>().HasKey(a => a.OrderStatusId);
            modelBuilder.Entity<Product114>().HasKey(a => a.ProductId);
            modelBuilder.Entity<Employee14>().HasKey(a => a.EmployeeId);
            modelBuilder.Entity<Employee11>().HasKey(a => a.EmployeeId1);
            modelBuilder.Entity<Product131>().HasKey(a => a.ProductId);
            modelBuilder.Entity<Employee31>().HasKey(a => a.EmployeeId);
            modelBuilder.Entity<Order101>().HasKey(a => a.OrderID);
            modelBuilder.Entity<OrderLine101>().HasKey(a => a.OrderLineId);
            modelBuilder.Entity<Product101>().HasKey(a => a.ProductId);
            modelBuilder.Entity<Order151>().HasKey(a => a.OrderID);
            modelBuilder.Entity<OrderLine151>().HasKey(a => a.OrderLineId);
            modelBuilder.Entity<Product151>().HasKey(a => a.ProductId);
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
            modelBuilder.Entity<Order74>().HasOne(a => a.Customer).WithMany(b => b.Order74s).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Order74>().HasOne(a => a.OrderStatus).WithMany(b => b.Order74s).HasForeignKey(c => c.OrderStatusId);
            modelBuilder.Entity<OrderLine74>().HasOne(a => a.Order).WithMany(b => b.OrderLine74s).HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderLine74>().HasOne(a => a.Product).WithMany(b => b.OrderLine74s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Sales55>().HasOne(a => a.Product).WithMany(b => b.Sales55s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Sales17>().HasOne(a => a.Product).WithMany(b => b.Sales17s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Order114>().HasOne(a => a.Customer).WithMany(b => b.Order114s).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Order114>().HasOne(a => a.OrderStatus).WithMany(b => b.Order114s).HasForeignKey(c => c.OrderStatusId);
            modelBuilder.Entity<OrderLine14>().HasOne(a => a.Order).WithMany(b => b.OrderLine14s).HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderLine14>().HasOne(a => a.Product).WithMany(b => b.OrderLine14s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<OrderLine114>().HasOne(a => a.Order).WithMany(b => b.OrderLine114s).HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderLine114>().HasOne(a => a.Product).WithMany(b => b.OrderLine114s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Sales21>().HasOne(a => a.Product).WithMany(b => b.Sales21s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Order101>().HasOne(a => a.Customer).WithMany(b => b.Order101s).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Order101>().HasOne(a => a.OrderStatus).WithMany(b => b.Order101s).HasForeignKey(c => c.OrderStatusId);
            modelBuilder.Entity<OrderLine101>().HasOne(a => a.Order).WithMany(b => b.OrderLine101s).HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderLine101>().HasOne(a => a.Product).WithMany(b => b.OrderLine101s).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Order151>().HasOne(a => a.Customer).WithMany(b => b.Order151s).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Order151>().HasOne(a => a.OrderStatus).WithMany(b => b.Order151s).HasForeignKey(c => c.OrderStatusId);
            modelBuilder.Entity<OrderLine151>().HasOne(a => a.Order).WithMany(b => b.OrderLine151s).HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderLine151>().HasOne(a => a.Product).WithMany(b => b.OrderLine151s).HasForeignKey(c => c.ProductId);
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
        public DbSet<OrderStatus35> OrderStatus35 { get; set; }
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
        public DbSet<Customer52> Customer52 { get; set; }
        public DbSet<Order74> Order74 { get; set; }
        public DbSet<OrderLine74> OrderLine74 { get; set; }
        public DbSet<Product74> Product74 { get; set; }
        public DbSet<OrderStatus15> OrderStatus15 { get; set; }
        public DbSet<Country55> Country55 { get; set; }
        public DbSet<Sales55> Sales55 { get; set; }
        public DbSet<OrderStatus24> OrderStatus24 { get; set; }
        public DbSet<Product18> Product18 { get; set; }
        public DbSet<OrderStatus17> OrderStatus17 { get; set; }
        public DbSet<Country17> Country17 { get; set; }
        public DbSet<Sales17> Sales17 { get; set; }
        public DbSet<Customer144> Customer144 { get; set; }
        public DbSet<Order114> Order114 { get; set; }
        public DbSet<OrderLine14> OrderLine14 { get; set; }
        public DbSet<OrderLine114> OrderLine114 { get; set; }
        public DbSet<Sales21> Sales21 { get; set; }
        public DbSet<OrderStatus3> OrderStatus3 { get; set; }
        public DbSet<Product114> Product114 { get; set; }
        public DbSet<Employee14> Employee14 { get; set; }
        public DbSet<Employee11> Employee11 { get; set; }
        public DbSet<Product131> Product131 { get; set; }
        public DbSet<Employee31> Employee31 { get; set; }
        public DbSet<Order101> Order101 { get; set; }
        public DbSet<OrderLine101> OrderLine101 { get; set; }
        public DbSet<Product101> Product101 { get; set; }
        public DbSet<Order151> Order151 { get; set; }
        public DbSet<OrderLine151> OrderLine151 { get; set; }
        public DbSet<Product151> Product151 { get; set; }
    }
}