using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Model
{
    public class LocalContext : DbContext
    {
        public LocalContext() : base("name=LocalContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<User> Users{ get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Post> Posts{ get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attend> Attends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>()
            //    .HasIndex(u => u.Email)
            //    .IsUnique();

            //table splitting
            modelBuilder.Entity<User>()
                .HasRequired(u => u.Details)
                .WithRequiredDependent(d => d.User);


            //entity splitting
            modelBuilder.Entity<Event>()
                .Map(map =>
                {
                    map.Properties(p => new
                    {
                        p.EventID,
                        p.Title,
                        p.FromDate,
                        p.ToDate,
                        p.Description
                    });
                    map.ToTable("Events");
                })
                //map to coordinate table
                .Map(map =>
                {
                    map.Properties(p => new
                    {
                        p.Longitude,
                        p.Latitude,
                        p.LocationName
                    });
                    map.ToTable("Coordinate");
                });
        }


    }
}
