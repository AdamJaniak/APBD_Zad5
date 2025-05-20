using Cw_5.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw_5.DAL;

public class PharmacyDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Perscription> Perscriptions { get; set; }
    public DbSet<PerscriptionMedicament> PerscriptionMedicaments { get; set; }

    protected PharmacyDbContext()
    {
    }

    public PharmacyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor()
            {
                IdDoctor = 1,
                FirstName = "Daniel",
                LastName = "Danov",
                Email = "danov@gmail.com",
            },
            new Doctor()
            {
                IdDoctor = 2,
                FirstName = "Daniel",
                LastName = "Doe",
                Email = "doe@gmail.com",
            },
            new Doctor()
            {
                IdDoctor = 3,
                FirstName = "Daniel",
                LastName = "Thompson",
                Email = "thompson@gmail.com",
            }
        );
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament()
            {
                IdMedicament = 1,
                Name = "Ibum",
                Description = "Syrup",
                Type = "anti-inflammatory"
            },
            new Medicament()
            {
                IdMedicament = 2,
                Name = "Paracetamol",
                Description = "Pills",
                Type = "analgesic"
            },
            new Medicament()
            {
                IdMedicament = 3,
                Name = "Strepsils",
                Description = "Pills",
                Type = "anti-bacterial"
            }
        );
        modelBuilder.Entity<Patient>().HasData(
            new Patient()
            {
                IdPatient = 1,
                FirstName = "Tom",
                LastName = "Jones",
                BirthDate = new DateTime(1980, 01, 01),
            },
            new Patient()
            {
                IdPatient = 2,
                FirstName = "Jake",
                LastName = "Phillips",
                BirthDate = new DateTime(1984, 02, 16),
            },
            new Patient()
            {
                IdPatient = 3,
                FirstName = "Jim",
                LastName = "Thomas",
                BirthDate = new DateTime(1950, 011, 25),
            }
        );
        modelBuilder.Entity<Perscription>().HasData(
            new Perscription()
            {
                IdPerscription = 1,
                Date = new DateTime(2018, 01, 01),
                DueDate = new DateTime(2020, 02, 01),
                IdPatient = 1,
                IdDoctor = 2
            },
            new Perscription()
            {
                IdPerscription = 2,
                Date = new DateTime(2018, 01, 01),
                DueDate = new DateTime(2020, 02, 01),
                IdPatient = 2,
                IdDoctor = 1
            },
            new Perscription()
            {
                IdPerscription = 3,
                Date = new DateTime(2018, 01, 01),
                DueDate = new DateTime(2020, 02, 01),
                IdPatient = 3,
                IdDoctor = 3
            }
        );
        modelBuilder.Entity<PerscriptionMedicament>()
            .HasKey(pm => new { pm.IdMedicament, pm.IdPerscription });
        modelBuilder.Entity<PerscriptionMedicament>().HasData(
            new PerscriptionMedicament()
            {
                IdMedicament = 1,
                IdPerscription = 2,
                Dose = 10,
                Details = "no details"
            },
            new PerscriptionMedicament()
            {
                IdMedicament = 2,
                IdPerscription = 1,
                Dose = 3,
                Details = "no details"
            }, new PerscriptionMedicament()
            {
                IdMedicament = 3,
                IdPerscription = 3,
                Dose = 1,
                Details = "no details"
            }
        );
    }
}