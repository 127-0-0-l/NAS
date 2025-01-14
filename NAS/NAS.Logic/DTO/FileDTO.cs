using System;

namespace NAS.Logic.DTO
{
    public class FileDTO
    {
        public int Id { get; set; }

        public int? FolderId { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string Path { get; set; }

        public long Size { get; set; }

        public long HashSum { get; set; }

        public byte[] Prewiew { get; set; }

        public string PrewiewExtension { get; set; }

        public bool IsInTrash { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public DateTime LastCheckedDateTime { get; set; }
    }
}
