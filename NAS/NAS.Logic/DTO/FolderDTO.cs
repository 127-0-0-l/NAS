using NAS.Storage.Entities;
using System.Collections.Generic;

namespace NAS.Logic.DTO
{
    public class FolderDTO
    {
        public int Id { get; set; }

        public int? ParentFolderId { get; set; }

        public string Name { get; set; }

        public virtual List<string> Folders { get; set; }

        public virtual List<FileDTO> Files { get; set; }
    }
}
