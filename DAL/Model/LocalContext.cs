using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class LocalContext : DbContext
    {
        public LocalContext() : base("name=LocalContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users{ get; set; }
        public DbSet<Post> Posts{ get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<Attend> Attends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }


    }
}
