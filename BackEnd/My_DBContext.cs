using BackEnd.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackEnd
{
    public class My_DBContext : DbContext
    {
        public My_DBContext()
           : base("name=My_DBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("Admin");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AdminRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AdminClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AdminLogin");
        }
    }
}