using DataMatrixCase.Domain.Entities;
using DataMatrixCase.Application.Interfaces.Repositories;
using DataMatrixCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMatrixCase.Persistence.Repositories
{
    public class DataMatrixInfoRepository : Repository<DataMatrixInfo>, IDataMatrixInfoRepository
    {
        public DataMatrixInfoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
