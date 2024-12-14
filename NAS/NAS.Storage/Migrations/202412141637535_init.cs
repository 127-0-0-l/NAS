namespace NAS.Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Partitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClasterId = c.Int(nullable: false),
                        Path = c.String(nullable: false),
                        TotalSpace = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clasters", t => t.ClasterId, cascadeDelete: true)
                .Index(t => t.ClasterId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartitionId = c.Int(nullable: false),
                        FolderId = c.Int(),
                        Path = c.String(nullable: false),
                        HashSum = c.Long(nullable: false),
                        IsInTrash = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        LastCheckedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Folders", t => t.FolderId)
                .ForeignKey("dbo.Partitions", t => t.PartitionId, cascadeDelete: true)
                .Index(t => t.PartitionId)
                .Index(t => t.FolderId);
            
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartitionId = c.Int(nullable: false),
                        ParentFolderId = c.Int(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Folders", t => t.ParentFolderId)
                .ForeignKey("dbo.Partitions", t => t.PartitionId, cascadeDelete: true)
                .Index(t => t.PartitionId)
                .Index(t => t.ParentFolderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "PartitionId", "dbo.Partitions");
            DropForeignKey("dbo.Files", "FolderId", "dbo.Folders");
            DropForeignKey("dbo.Folders", "PartitionId", "dbo.Partitions");
            DropForeignKey("dbo.Folders", "ParentFolderId", "dbo.Folders");
            DropForeignKey("dbo.Partitions", "ClasterId", "dbo.Clasters");
            DropIndex("dbo.Folders", new[] { "ParentFolderId" });
            DropIndex("dbo.Folders", new[] { "PartitionId" });
            DropIndex("dbo.Files", new[] { "FolderId" });
            DropIndex("dbo.Files", new[] { "PartitionId" });
            DropIndex("dbo.Partitions", new[] { "ClasterId" });
            DropTable("dbo.Folders");
            DropTable("dbo.Files");
            DropTable("dbo.Partitions");
            DropTable("dbo.Clasters");
        }
    }
}
