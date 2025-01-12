using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NAS.Storage.Entities
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ParentFolder))]
        public int? ParentFolderId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Folder ParentFolder { get; set; }

        public virtual ICollection<Folder> Folders { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
