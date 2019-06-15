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

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
