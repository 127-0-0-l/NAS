using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAS.Web.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public ImageModel Prewiew { get; set; }
    }
}
