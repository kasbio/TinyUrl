using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Core;

namespace TinyUrl.EntityFrameworkCore
{
    public  class TinyUrlDbContext:DbContext
    {
        public DbSet<TinyUrlEntity> Urls { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entity = modelBuilder.Entity<TinyUrlEntity>();
            entity.HasIndex(o => o.ShortUrl)
                .IsUnique();

            entity.Property(o => o.CreateTime)
                .ValueGeneratedOnAdd();

            
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            string connection = "Server=localhost;Initial Catalog=dev;User Id=root;Password=123456;";
            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }
    }
}
