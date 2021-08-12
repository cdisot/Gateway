

using CC.Core.Mapping;
using CC.Core.Repositories;
using Domain.Core.CoreData;
using Domain.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CC.Core.DataPersistent
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public IQueryable<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>().AsNoTracking<TEntity>();
        }

        public void Delete<TEntity>(TEntity item) where TEntity : class
        {
            Set<TEntity>().Remove(item);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Gateway;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString,
           options => options.EnableRetryOnFailure());
        }
      
        private void OneToManyRelationshipConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gateway>()
                .HasMany(c => (List<Device>)c.Devices)
                .WithOne(s => (Gateway)s.Gateway);


            modelBuilder.Entity<Device>()
                         .HasOne(s => (Gateway)s.Gateway)
                          .WithMany(c => (List<Device>)c.Devices);


            modelBuilder.Entity<Status>()
               .HasMany(c => (List<Device>)c.Devices)
               .WithOne(s => (Status)s.Status);


            modelBuilder.Entity<Device>()
                        .HasOne(s => (Status)s.Status)
                         .WithMany(c => (List<Device>)c.Devices);
                         


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Gateway>();
            modelBuilder.Entity<Device>();
            modelBuilder.Entity<Status>();
            OneToManyRelationshipConfiguration(modelBuilder);
            /*

            modelBuilder.Entity<Device>()
                .HasOne(g => (Gateway)g.Gateway)
                .WithMany()
                .HasPrincipalKey(g => g.Id)
                .HasForeignKey(d => d.Gateway_Id);

            modelBuilder.Entity<Device>()
                           .HasOne(g => (StatusS)g.Status)
                             .WithMany()
                           .HasPrincipalKey(g => g.Id)
                           .HasForeignKey(d => d.Status_Id);



            modelBuilder.Entity<Gateway>()
               .HasMany(d => (List<Device>)d.Devices)
               .WithOne(g => (Gateway)g.Gateway)
               .HasPrincipalKey(d => d.Id)
               .HasForeignKey(g => g.Gateway_Id);


            modelBuilder.Entity<Status>()
.HasMany(d => (List<Device>)d.Devices)
.WithOne(g => (Status)g.Status)
.HasPrincipalKey(d => d.Id)
.HasForeignKey(g => g.Status_Id);
*/

            base.OnModelCreating(modelBuilder);
        }

    }
}
