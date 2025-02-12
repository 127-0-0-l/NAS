using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAS.Web.Models
{
    public class FolderContentModel
    {
        public string Path { get; set; }
        public List<FolderModel> Folders { get; set; }
        public List<FileModel> Files { get; set; }
    }
}
