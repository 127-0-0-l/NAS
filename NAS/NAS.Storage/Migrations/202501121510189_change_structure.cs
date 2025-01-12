namespace NAS.Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_structure : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Clasters", newName: "Disks");
            DropForeignKey("dbo.Files", "PartitionId", "dbo.Partitions");
            DropForeignKey("dbo.Folders", "PartitionId", "dbo.Partitions");
            DropIndex("dbo.Files", new[] { "PartitionId" });
            DropIndex("dbo.Folders", new[] { "PartitionId" });
            DropColumn("dbo.Files", "PartitionId");
            DropColumn("dbo.Folders", "PartitionId");
            //RenameColumn(table: "dbo.Files", name: "PartitionId", newName: "Partition_Id");
            //RenameColumn(table: "dbo.Folders", name: "PartitionId", newName: "Partition_Id");
            RenameColumn(table: "dbo.Partitions", name: "ClasterId", newName: "DiskId");
            RenameIndex(table: "dbo.Partitions", name: "IX_ClasterId", newName: "IX_DiskId");
            AddColumn("dbo.Disks", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Partitions", "Letter", c => c.String(nullable: false));
            AddColumn("dbo.Partitions", "FreeSpace", c => c.Long(nullable: false));
            AddColumn("dbo.Files", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Files", "Extension", c => c.String());
            AddColumn("dbo.Files", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.Files", "Prewiew", c => c.Binary());
            AddColumn("dbo.Files", "PrewiewExtension", c => c.String());
            //AlterColumn("dbo.Files", "Partition_Id", c => c.Int());
            //AlterColumn("dbo.Folders", "Partition_Id", c => c.Int());
            //CreateIndex("dbo.Files", "Partition_Id");
            //CreateIndex("dbo.Folders", "Partition_Id");
            //AddForeignKey("dbo.Files", "Partition_Id", "dbo.Partitions", "Id");
            //AddForeignKey("dbo.Folders", "Partition_Id", "dbo.Partitions", "Id");
            DropColumn("dbo.Partitions", "Path");
            DropColumn("dbo.Files", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Partitions", "Path", c => c.String(nullable: false));
            //DropForeignKey("dbo.Folders", "Partition_Id", "dbo.Partitions");
            //DropForeignKey("dbo.Files", "Partition_Id", "dbo.Partitions");
            //DropIndex("dbo.Folders", new[] { "Partition_Id" });
            //DropIndex("dbo.Files", new[] { "Partition_Id" });
            //AlterColumn("dbo.Folders", "Partition_Id", c => c.Int(nullable: false));
            //AlterColumn("dbo.Files", "Partition_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Files", "PartitionId", c => c.Int());
            AddColumn("dbo.Folders", "PartitionId", c => c.Int());
            DropColumn("dbo.Files", "PrewiewExtension");
            DropColumn("dbo.Files", "Prewiew");
            DropColumn("dbo.Files", "Size");
            DropColumn("dbo.Files", "Extension");
            DropColumn("dbo.Files", "Name");
            DropColumn("dbo.Partitions", "FreeSpace");
            DropColumn("dbo.Partitions", "Letter");
            DropColumn("dbo.Disks", "Name");
            RenameIndex(table: "dbo.Partitions", name: "IX_DiskId", newName: "IX_ClasterId");
            RenameColumn(table: "dbo.Partitions", name: "DiskId", newName: "ClasterId");
            //RenameColumn(table: "dbo.Folders", name: "Partition_Id", newName: "PartitionId");
            //RenameColumn(table: "dbo.Files", name: "Partition_Id", newName: "PartitionId");
            CreateIndex("dbo.Folders", "PartitionId");
            CreateIndex("dbo.Files", "PartitionId");
            AddForeignKey("dbo.Folders", "PartitionId", "dbo.Partitions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Files", "PartitionId", "dbo.Partitions", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Disks", newName: "Clasters");
        }
    }
}
