﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NAS.Storage.Entities
{
    public class Disk
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Partition> Partitions { get; set; }
    }
}
