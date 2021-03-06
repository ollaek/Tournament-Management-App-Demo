﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BackEnd.Models
{
    // You can add profile data for the user by adding more properties to your Admin class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Admin : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Admin> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<Admin>
    {
        public ApplicationDbContext()
            : base("My_DBContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admin>()
                .ToTable("Admin", "dbo").Property(p => p.Id).HasColumnName("AdminId");

            modelBuilder.Entity<IdentityRole>().ToTable("AdminRole");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AdminUserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AdminClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AdminLogin");
        }
    }
}