using DataMatrixCase.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMatrixCase.Infrastructure.Interfaces.Services
{
    public interface IDataMatrixService
    {
        public Task<List<DataMatrixInfoDto>> DecodedItems();
        public Task ClearAll();
        public Task<List<string>> Decode(MemoryStream stream, string fileName);
    }
}
