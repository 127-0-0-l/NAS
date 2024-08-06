using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
                disks.Add(new Disk(i, Convert.ToInt64(Console.ReadLine())));
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            long volume = 0;
            int counter = 0;

            do
            {
                Disk disk1 = disks
                    .OrderByDescending(d => d.FreeSpace)
                    .First();

                Disk disk2 = disks
                    .Where(d => d.Id != disk1.Id)
                    .OrderByDescending(d => d.FreeSpace)
                    .First();

                volume = disks
                    .Where(d => d.FreeSpace > 0)
                    .OrderByDescending(d => d.FreeSpace)
                    .Last().FreeSpace / 2;

                volume = volume > 0 ? volume : 1;

                if (disk1.Parts.ContainsKey(disk2.Id))
                {
                    disk1.Parts[disk2.Id] += volume;
                    disk2.Parts[disk1.Id] += volume;
                }
                else
                {
                    disk1.Parts.Add(disk2.Id, volume);
                    disk2.Parts.Add(disk1.Id, volume);
                }
                counter++;
            }
            while (disks.Where(d => d.FreeSpace > 0).Count() > 1);
            sw.Stop();
            foreach (var disk in disks)
            {
                Console.WriteLine($"disk {disk.Id}: {disk.Volume} : {disk.FreeSpace}");
                foreach (var part in disk.Parts)
                {
                    Console.WriteLine($"{part.Key}: {part.Value}");
                }
            }
            
            Console.WriteLine(sw.Elapsed.ToString());
            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }

    class Disk
    {
        public int Id { get; set; }
        public long Volume {  get; set; }
        public Dictionary<int, long> Parts { get; set; } = new Dictionary<int, long>();
        public long FreeSpace
        {
            get
            {
                return Volume - Parts.Sum(p => p.Value);
            }
        }
        public Disk(int id, long volume)
        {
            Id = id;
            Volume = volume;
        }
    }
}
