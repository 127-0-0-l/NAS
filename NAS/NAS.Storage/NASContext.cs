using NAS.Storage.Entities;
using System.Data.Entity;

namespace NAS.Storage
{
    public class NASContext : DbContext
    {
        public NASContext()
            : base("name=NASContext")
        {
        }

        public DbSet<Disk> Disks { get; set; }
        public DbSet<Partition> Partitions { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}