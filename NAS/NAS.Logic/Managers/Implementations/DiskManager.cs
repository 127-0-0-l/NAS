using NAS.Logic.DTO;
using NAS.Logic.Managers.Interfaces;
using NAS.Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAS.Logic.Managers.Implementations
{
    public class DiskManager : BaseManager, IDiskManager
    {
        public List<DiskDTO> GetAll()
        {
            return _context.Disks.Select(d => EntityToDTO(d)).ToList();
        }

        public DiskDTO GetById(int id)
        {
            Disk disk = _context.Disks.FirstOrDefault(d => d.Id == id);
            if (disk == null)
                return null;

            return EntityToDTO(disk);
        }

        public int Add(DiskDTO item)
        {
            Disk newDisk = new Disk
            {
                Name = item.Name
            };

            _context.Disks.Add(newDisk);
            return _context.SaveChanges();
        }

        public bool Remove(int id)
        {
            Disk disk = _context.Disks.FirstOrDefault(d => d.Id == id);

            if (disk != null)
            {
                _context.Disks.Remove(disk);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(DiskDTO item)
        {
            Disk disk = _context.Disks.FirstOrDefault(d => d.Id == item.Id);

            if (disk != null)
            {
                disk.Name = item.Name;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public static DiskDTO EntityToDTO(Disk disk)
        {
            if (disk == null)
                return null;

            return new DiskDTO
            {
                Id = disk.Id,
                Name = disk.Name,
                Partitions = disk.Partitions
                    .Select(p => PartitionManager.EntityToDTO(p)).ToList()
            };
        }
    }
}
