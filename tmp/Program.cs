using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("count: ");
            int dskCount = Convert.ToInt32(Console.ReadLine());
            List<Disk> disks = new List<Disk>();

            for (int i = 0; i < dskCount; i++)
            {
                Console.Write($"{i + 1}: ");
                disks.Add(new Disk(i, Convert.ToInt32(Console.ReadLine())));
            }

            do
            {
                Disk diskForData = disks
                    .OrderByDescending(d => d.FreeSpace)
                    .First();

                Disk diskForCopy = disks
                    .Where(d => d.Id != diskForData.Id)
                    .OrderByDescending(d => d.FreeSpace)
                    .First();

                int diskIdForData =
                    diskForData.Parts.Count(p => p.DiskId == diskForData.Id)
                    >= diskForData.Parts.Count(p => p.DiskId == diskForCopy.Id)
                    ? diskForData.Id : diskForCopy.Id;

                diskForData.Parts.Add(new Part(diskIdForData, 1));
                diskForCopy.Parts.Add(new Part(diskIdForData, 1));
            }
            while (disks.Where(d => d.FreeSpace > 0).Count() > 1);

            foreach (var disk in disks)
            {
                Console.WriteLine($"disk {disk.Id}: {disk.Volume} : {disk.FreeSpace}");
                //foreach (var part in disk.Parts)
                //{
                //    Console.WriteLine()
                //}
            }
            Console.ReadKey();
        }
    }

    class Disk
    {
        public int Id { get; set; }
        public int Volume {  get; set; }
        public List<Part> Parts { get; set; } = new List<Part>();
        public int FreeSpace
        {
            get
            {
                return Volume - Parts.Select(p => p.Volume).Sum();
            }
        }
        public Disk(int id, int volume)
        {
            Id = id;
            Volume = volume;
        }
    }

    class Part
    {
        public int DiskId { get; set; }
        public int Volume { get; set; }
        public Part (int diskId, int volume)
        {
            DiskId = diskId;
            Volume = volume;
        }
    }
}
