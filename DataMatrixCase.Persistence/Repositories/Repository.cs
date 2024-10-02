using DataMatrixCase.Domain.Entities;
using DataMatrixCase.Application.Interfaces;
using DataMatrixCase.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMatrixCase.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Table { get => _context.Set<T>(); }

        public async Task<T> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task ClearAllAsync()
        {
            await Table.ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

    }
}
