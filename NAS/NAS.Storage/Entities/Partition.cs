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
        [ForeignKey(nameof(Claster))]
        public int ClasterId { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public long TotalSpace { get; set; }

        public virtual Claster Claster { get; set; }

        public virtual ICollection<Folder> Folders { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
