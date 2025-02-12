using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAS.Web.Models
{
    public class ImageModel
    {
        byte[] Image { get; set; }
        string MimeType { get; set; }
    }
}
