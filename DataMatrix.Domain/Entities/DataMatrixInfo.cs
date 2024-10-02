using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMatrixCase.Domain.Entities
{
    [Table("datamatrix_info")]
    public class DataMatrixInfo : BaseEntity
    {
        [Required]
        [Column("decoded_data", TypeName = "nvarchar(max)")]
        public string DecodedData { get; set; }

        [Required]
        [Column("file_path", TypeName = "nvarchar(max)")]
        public string FilePath { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

