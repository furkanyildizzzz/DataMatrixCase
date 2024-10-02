using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMatrixCase.Application.Dto
{
    public class DataMatrixInfoDto
    {
        public string FileName { get; set; }
        public string DecodedData { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
