using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NAS.Storage.Entities
{
    public class Partition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Disk))]
        public int DiskId { get; set; }

        [Required]
        public string Letter { get; set; }

        [Required]
        public long TotalSpace { get; set; }

        [Required]
        public long FreeSpace { get; set; }

        public virtual Disk Disk { get; set; }

        public virtual ICollection<Folder> Folders { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
