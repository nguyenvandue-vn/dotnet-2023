﻿using Microsoft.EntityFrameworkCore;

namespace BicycleRentals.Domain;

/// <summary>
/// Database for bicycle's rentals
/// </summary>
public class BicycleRentalContext : DbContext
{
    /// <summary>
    /// List types.
    /// </summary>
    public DbSet<BicycleType> BicycleTypes { get; set; } = null!;

    /// <summary>
	/// List bicycles.
	/// </summary>
	public DbSet<Bicycle> Bicycles { get; set; } = null!;

    /// <summary>
    /// List customers.
    /// </summary>
    public DbSet<Customer> Customers { get; set; } = null!;

    /// <summary>
    /// List rentals.
    /// </summary>
    public DbSet<BicycleRental> BicycleRentals { get; set; } = null!;

    public BicycleRentalContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Fill in the data tables.
    /// </summary>
    /// <param name="modelBuilder">Model Builder.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BicycleType>().HasData(
            new List<BicycleType>() 
            {
                new BicycleType{TypeId = 1,TypeName = "Mountain",RentalPricePerHour = 10 },
                new BicycleType{TypeId = 2,TypeName = "City",RentalPricePerHour = 8},
                new BicycleType{TypeId = 3,TypeName = "Sport",RentalPricePerHour = 15}
            });

        modelBuilder.Entity<Bicycle>().HasData(
            new List<Bicycle>() {
                new Bicycle {SerialNumber = 1,TypeId = 1,Model = "Trek X-Caliber 7",Color = "Black"},
                new Bicycle {SerialNumber = 2,TypeId = 2,Model = "Specialized Sirrus 2.0",Color = "Red"},
                new Bicycle {SerialNumber = 3,TypeId = 3,Model = "Cannondale Synapse Carbon Disc 105",Color = "White"},
                new Bicycle {SerialNumber = 4,TypeId = 1,Model = "Giant Talon 3",Color = "Green"},
                new Bicycle {SerialNumber = 5,TypeId = 2,Model = "Raleigh Detour 2",Color = "Blue"},
                new Bicycle {SerialNumber = 6,TypeId = 2,Model = "Giant Escape 3",Color = "Grey"},
                new Bicycle {SerialNumber = 7,TypeId = 1,Model = "Norco Storm",Color = "Blue"},
                new Bicycle {SerialNumber = 8,TypeId = 1,Model = "Scott Aspect",Color = "White"},
                new Bicycle {SerialNumber = 9,TypeId = 3,Model = "Giant TCR",Color = "Black"},
                new Bicycle {SerialNumber = 10,TypeId = 2,Model = "Schwinn Discover",Color = "Blue"}
            });
        
        modelBuilder.Entity<Customer>().HasData(
            new List<Customer>() {
                new Customer {Id = 1,FullName = "Ivanov Ivan Ivanovich",BirthYear = 1980,Phone = "+79123456789"},
                new Customer {Id = 2,FullName = "Petrov Petr Petrovich",BirthYear = 1995,Phone = "+79234567890"},
                new Customer {Id = 3,FullName = "Sidorova Olga Vladimirovna",BirthYear = 1987,Phone = "+79345678901"},
                new Customer {Id = 4,FullName = "Kozlov Dmitry Igorevich",BirthYear = 1978,Phone = "+79456789012"},
                new Customer {Id = 5,FullName = "Makarov Alexey Andreevich",BirthYear = 1990,Phone = "+79567890123"}
            });

        modelBuilder.Entity<BicycleRental>().HasData(
            new List<BicycleRental>() {
                new BicycleRental { RentalId = 1, SerialNumber = 1, CustomerId = 1, RentalTime = 1 },
                new BicycleRental { RentalId = 2, SerialNumber = 3, CustomerId = 2, RentalTime = 2 },
                new BicycleRental { RentalId = 3, SerialNumber = 4, CustomerId = 3, RentalTime = 1 },
                new BicycleRental { RentalId = 4, SerialNumber = 5, CustomerId = 4, RentalTime = 3 },
                new BicycleRental { RentalId = 5, SerialNumber = 1, CustomerId = 5, RentalTime = 1 },
                new BicycleRental { RentalId = 6, SerialNumber = 4, CustomerId = 4, RentalTime = 2 },
                new BicycleRental { RentalId = 7, SerialNumber = 9, CustomerId = 3, RentalTime = 3 },
                new BicycleRental { RentalId = 8, SerialNumber = 10, CustomerId = 4, RentalTime = 1 },
                new BicycleRental { RentalId = 9, SerialNumber = 6, CustomerId = 2, RentalTime = 2 },
                new BicycleRental { RentalId = 10, SerialNumber = 5, CustomerId = 1, RentalTime = 3 },
                new BicycleRental { RentalId = 11, SerialNumber = 2, CustomerId = 4, RentalTime = 1 },
                new BicycleRental { RentalId = 12, SerialNumber = 7, CustomerId = 2, RentalTime = 2 },
                new BicycleRental { RentalId = 13, SerialNumber = 8, CustomerId = 1, RentalTime = 3}
            });

        modelBuilder.Entity<BicycleType>().HasKey(bt => bt.TypeId);
        modelBuilder.Entity<Bicycle>().HasKey(b => b.SerialNumber);
        modelBuilder.Entity<Customer>().HasKey(c => c.Id);
        modelBuilder.Entity<BicycleRental>().HasKey(br => br.RentalId);


        modelBuilder.Entity<Bicycle>()
                    .HasOne<BicycleType>(b => b.BicycleType)
                    .WithMany(t => t.Bicycles)
                    .HasForeignKey(b => b.TypeId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BicycleRental>()
                    .HasOne<Bicycle>(r => r.Bicycle)
                    .WithMany(b => b.Rentals)
                    .HasForeignKey(r => r.SerialNumber)
                    .OnDelete(DeleteBehavior.Cascade); ;

        modelBuilder.Entity<BicycleRental>()
                    .HasOne<Customer>(r => r.Customer)
                    .WithMany(c => c.Rentals)
                    .HasForeignKey(r => r.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade); ;

    }
}
