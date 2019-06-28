using DAL.Core.Domain;
using System.Data.Entity;

namespace DAL.Persistence
{
    public class My_DBContext : DbContext
    {
        public My_DBContext()
            : base("name=My_DBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminClaim> AdminClaims { get; set; }
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<AdminRole> AdminRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Phase> Phases { get; set; }
        public virtual DbSet<Leg> Legs { get; set; }
        public virtual DbSet<TournamentPhase> TournamentPhases { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
               .HasMany(e => e.AdminClaims)
               .WithRequired(e => e.Admin)
               .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.AdminLogins)
                .WithRequired(e => e.Admin)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.AdminRoles)
                .WithMany(e => e.Admins)
                .Map(m => m.ToTable("AdminUserRole").MapLeftKey("UserId").MapRightKey("RoleId"));

            modelBuilder.Entity<User>()
               .HasMany(e => e.UserClaims)
               .WithRequired(e => e.User)
               .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserLogins)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("UserUserRole").MapLeftKey("UserId").MapRightKey("RoleId"));
        }
    }
}
