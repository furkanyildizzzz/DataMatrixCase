using DataMatrixCase.Application.Interfaces;
using DataMatrixCase.Application.Interfaces.Repositories;
using DataMatrixCase.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMatrixCase.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IDataMatrixInfoRepository DataMatrixInfoRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IDataMatrixInfoRepository dataMatrixInfoRepository)
        {
            _context = context;
            DataMatrixInfoRepository = dataMatrixInfoRepository;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }
    }
}
