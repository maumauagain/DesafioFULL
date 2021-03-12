using System;
using System.Collections.Generic;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Divida> Dividas { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Divida>().HasKey(d => d.Id);
            builder.Entity<Divida>().HasQueryFilter(d => d.Removed == false);

            builder.Entity<Parcela>().HasKey(p => p.Id);
            builder.Entity<Parcela>().HasQueryFilter(p => p.Removed == false);

            builder.Entity<Divida>()
                .HasData(new List<Divida>(){
                    new Divida(1, 1010, "José", "123456", 1, 2, false, DateTime.UtcNow),
                    new Divida(2, 1011, "João", "123777", 2, 4, false, DateTime.UtcNow)
                });

            builder.Entity<Parcela>()
                .HasData(new List<Parcela>(){
                    new Parcela(1, 1, new DateTime(2020, 11, 9), 100, 1, false, DateTime.UtcNow),
                    new Parcela(2, 2, new DateTime(2020, 12, 9), 100, 1, false, DateTime.UtcNow),
                    new Parcela(3, 3, new DateTime(2020, 12, 5), 200, 2, false, DateTime.UtcNow),
                    new Parcela(4, 4, new DateTime(2021, 1, 5), 200, 2, false, DateTime.UtcNow)
                });

        }
    }
}
