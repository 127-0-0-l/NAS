using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NAS.Storage.Entities
{
    public class File
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Folder))]
        public int? FolderId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Extension { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public long Size { get; set; }

        [Required]
        public long HashSum { get; set; }

        public byte[] Prewiew { get; set; }

        public string PrewiewExtension { get; set; }

        public bool IsInTrash { get; set; }

        [Required]
        public DateTime ModifiedDateTime { get; set; }

        [Required]
        public DateTime LastCheckedDateTime { get; set; }

        public virtual Folder Folder { get; set; }
    }
}
