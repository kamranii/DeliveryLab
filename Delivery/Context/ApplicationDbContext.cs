using System;
using Delivery.Entities;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Context
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			:base(options)
		{
		}
		public DbSet<Factory> Factories { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Cargo> Cargos { get; set; }
		public DbSet<CargoProduct> CargoProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//factory
			modelBuilder.Entity<Factory>()
				 .ToTable("Factory")
				 .HasKey(f => f.Id);
			//category
			modelBuilder.Entity<Category>()
				.ToTable("Category")
				.HasKey(c => c.Id);
			modelBuilder.Entity<Category>()
				.Property(c => c.DeliveryTime).HasColumnName("EstimatedDelivery");
			//product table
			modelBuilder.Entity<Product>()
				.ToTable("Product")
				.HasKey(p => p.Id);
			//product-factory relationship
			modelBuilder.Entity<Product>()
				.HasOne(p => p.Factory)
				.WithMany(f => f.Products);
			//product-category rel
			modelBuilder.Entity<Product>()
				.HasOne(p => p.Category)
				.WithMany(c => c.Products);
			//cargo
			modelBuilder.Entity<Cargo>()
				.ToTable("Cargo")
				.HasKey(c => c.Id);
			//cargo-product
			modelBuilder.Entity<CargoProduct>()
				.ToTable("CargoProduct")
				.HasKey(cp => cp.Id);
			//cargo-product relationships
            modelBuilder.Entity<CargoProduct>()
				.HasOne(cp => cp.Cargo)
				.WithMany(ca => ca.CargoProducts)
				.HasForeignKey(cp => cp.CargoId);

            modelBuilder.Entity<CargoProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(pr => pr.ProductCargoes)
                .HasForeignKey(cp => cp.ProductId);
        }
    }
}

