using NAS.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAS.Logic.Managers
{
    public abstract class BaseManager
    {
        public readonly NASContext _context;

        public BaseManager()
        {
            _context = new NASContext();
        }
    }
}
