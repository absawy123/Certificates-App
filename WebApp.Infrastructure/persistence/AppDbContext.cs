using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using WebApp.Core.models;

namespace WebApp.Infrastructure.persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public AppDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = config.GetConnectionString("constr");
            optionsBuilder.UseSqlServer(connectionString);

        }


        public DbSet<Location> Locations { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateTitle> CertificateTitles { get; set; }
        public DbSet<CertificateType> CertificateTypes { get; set; }
        public DbSet<InspectedItem> InspectedItems { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ReferenceStandared> References { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);


            // seed Roles
            builder.Entity<ApplicationRole>().HasData(
            new ApplicationRole { Id = 1, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
            new ApplicationRole { Id = 2, Name = "Inspector", NormalizedName = "INSPECTOR" },
            new ApplicationRole { Id = 3, Name = "Admin", NormalizedName = "ADMIN" },
            new ApplicationRole { Id = 4, Name = "Client", NormalizedName = "CLIENT" }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = 1,
                    UserName = "ahmedemam@mail.com",
                    NormalizedUserName = "AHMEDEMAM@MAIL.COM",
                    Email = "ahmedemam@mail.com",
                    NormalizedEmail = "AHMEDEMAM@MAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new ApplicationUser(), "12345678"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
     {
         Id = 2,
         UserName = "ahmedtaher@mail.com",
         NormalizedUserName = "AHMEDTAHER@MAIL.COM",
         Email = "ahmedtaher@mail.com",
         NormalizedEmail = "AHMEDTAHER@MAIL.COM",
         EmailConfirmed = true,
         PasswordHash = hasher.HashPassword(new ApplicationUser(), "12345678"),
         SecurityStamp = Guid.NewGuid().ToString()
     },
                new ApplicationUser
     {
         Id = 3,
         UserName = "admin@mail.com",
         NormalizedUserName = "ADMIN@MAIL.COM",
         Email = "admin@mail.com",
         NormalizedEmail = "ADMIN@MAIL.COM",
         EmailConfirmed = true,
         PasswordHash = hasher.HashPassword(new ApplicationUser(), "12345678"),
         SecurityStamp = Guid.NewGuid().ToString()
     },
                new ApplicationUser
     {
         Id = 4,
         UserName = "client@mail.com",
         NormalizedUserName = "CLIENT@MAIL.COM",
         Email = "client@mail.com",
         NormalizedEmail = "CLIENT@MAIL.COM",
         EmailConfirmed = true,
         PasswordHash = hasher.HashPassword(new ApplicationUser(), "12345678"),
         SecurityStamp = Guid.NewGuid().ToString()
     }
            );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 }, // SuperAdmin
                new IdentityUserRole<int> { UserId = 2, RoleId = 2 }, // Inspector 
                new IdentityUserRole<int> { UserId = 3, RoleId = 3 }, // admin 
                new IdentityUserRole<int> { UserId = 4, RoleId = 4 }  // client
            );

        }

    }
}
