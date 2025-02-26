using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyAuthApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Workshop> Workshops { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin") { NormalizedName = "ADMIN" };
            var user = new IdentityRole("user") { NormalizedName = "USER" };

            builder.Entity<IdentityRole>().HasData(admin, user);
        }
    }

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
    }

    public class Workshop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime DateTime { get; set; }

        public string AdditionalInfo { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;
    }
}
