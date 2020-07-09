using System;
using Hudys.PlanilhaFinanceira.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Hudys.PlanilhaFinanceira.Infra.Data
{
    public class PlanilhaFinanceiraDbContext : DbContext
    {
        public DbSet<TransactionType> TransactionTypes { get; set; }

        public PlanilhaFinanceiraDbContext(DbContextOptions<PlanilhaFinanceiraDbContext> options) : base(options)
        {

        }

        public PlanilhaFinanceiraDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Pooling=true;Database=FinancialManager;User Id=postgres;Password=SuperSecret;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Icon).HasMaxLength(60);
                entity.Property(e => e.Name).HasMaxLength(255);
            });
        }
    }
}
