using DataMatrixCase.Domain.Entities;
using DataMatrixCase.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataMatrixCase.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<DataMatrixInfo> DataMatrixInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}