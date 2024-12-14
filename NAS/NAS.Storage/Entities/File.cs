using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NAS.Storage.Entities
{
    public class File
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Partition))]
        public int PartitionId { get; set; }

        [ForeignKey(nameof(Folder))]
        public int? FolderId { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public long HashSum { get; set; }

        public bool IsInTrash { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public DateTime ModifiedDateTime { get; set; }

        [Required]
        public DateTime LastCheckedDateTime { get; set; }

        public virtual Partition Partition { get; set; }

        public virtual Folder Folder { get; set; }
    }
}
