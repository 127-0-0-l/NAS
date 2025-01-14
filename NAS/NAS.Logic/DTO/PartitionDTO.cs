using NAS.Storage.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAS.Logic.DTO
{
    public class PartitionDTO
    {
        public int Id { get; set; }

        public int DiskId { get; set; }

        public string Letter { get; set; }

        public long TotalSpace { get; set; }

        public long FreeSpace { get; set; }
    }
}
