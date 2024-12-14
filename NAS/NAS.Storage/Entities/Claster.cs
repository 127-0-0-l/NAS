using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NAS.Storage.Entities
{
    public class Claster
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Partition> Partitions { get; set; }
    }
}
