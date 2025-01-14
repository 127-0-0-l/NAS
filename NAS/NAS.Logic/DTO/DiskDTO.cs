using System.Collections.Generic;

namespace NAS.Logic.DTO
{
    public class DiskDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<PartitionDTO> Partitions { get; set; }
    }
}
