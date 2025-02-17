using NAS.Logic.DTO;
using NAS.Logic.Managers.Interfaces;
using NAS.Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAS.Logic.Managers.Implementations
{
    public class PartitionManager : BaseManager, IPartitionManager
    {
        public List<PartitionDTO> GetAll()
        {
            return _context.Partitions.ToList().Select(p => EntityToDTO(p)).ToList();
        }

        public PartitionDTO GetById(int id)
        {
            Partition partition = _context.Partitions.FirstOrDefault(p => p.Id == id);

            if (partition == null)
                return null;

            return EntityToDTO(partition);
        }

        public int Add(PartitionDTO item)
        {
            Partition newPartition = new Partition
            {
                Letter = item.Letter,
                TotalSpace = item.TotalSpace,
                FreeSpace = item.FreeSpace
            };

            Disk disk = _context.Disks.FirstOrDefault(d => d.Id == item.DiskId);
            newPartition.Disk = disk;

            _context.SaveChanges();
            return _context.SaveChanges();
        }

        public bool Remove(int id)
        {
            Partition partition = _context.Partitions.FirstOrDefault(p => p.Id == id);

            if (partition != null)
            {
                _context.Partitions.Remove(partition);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(PartitionDTO item)
        {
            Partition partition = _context.Partitions.FirstOrDefault(p => p.Id == item.Id);

            if (partition != null)
            {
                partition.Letter = item.Letter;
                partition.TotalSpace = item.TotalSpace;
                partition.FreeSpace = item.FreeSpace;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public static PartitionDTO EntityToDTO(Partition partition)
        {
            if (partition == null)
                return null;

            return new PartitionDTO
            {
                Id = partition.Id,
                DiskId = partition.DiskId,
                Letter = partition.Letter,
                TotalSpace = partition.TotalSpace,
                FreeSpace = partition.FreeSpace
            };
        }
    }
}
