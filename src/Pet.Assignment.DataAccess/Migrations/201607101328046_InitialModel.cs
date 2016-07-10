namespace Pet.Assignment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OwnersWalkers",
                c => new
                    {
                        PetOwnerId = c.Int(nullable: false),
                        PetWalkerId = c.Int(nullable: false),
                        HasApproval = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.PetOwnerId, t.PetWalkerId })
                .ForeignKey("dbo.PetOwners", t => t.PetOwnerId)
                .ForeignKey("dbo.PetWalkers", t => t.PetWalkerId)
                .Index(t => t.PetOwnerId)
                .Index(t => t.PetWalkerId);
            
            CreateTable(
                "dbo.PetOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PetWalkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PetsPetOwners",
                c => new
                    {
                        PetId = c.Int(nullable: false),
                        PetOwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PetId, t.PetOwnerId })
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .ForeignKey("dbo.PetOwners", t => t.PetOwnerId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.PetOwnerId);
            
            CreateTable(
                "dbo.PetsPetWalkers",
                c => new
                    {
                        PetId = c.Int(nullable: false),
                        PetWalkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PetId, t.PetWalkerId })
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .ForeignKey("dbo.PetWalkers", t => t.PetWalkerId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.PetWalkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OwnersWalkers", "PetWalkerId", "dbo.PetWalkers");
            DropForeignKey("dbo.OwnersWalkers", "PetOwnerId", "dbo.PetOwners");
            DropForeignKey("dbo.PetsPetWalkers", "PetWalkerId", "dbo.PetWalkers");
            DropForeignKey("dbo.PetsPetWalkers", "PetId", "dbo.Pets");
            DropForeignKey("dbo.PetsPetOwners", "PetOwnerId", "dbo.PetOwners");
            DropForeignKey("dbo.PetsPetOwners", "PetId", "dbo.Pets");
            DropIndex("dbo.PetsPetWalkers", new[] { "PetWalkerId" });
            DropIndex("dbo.PetsPetWalkers", new[] { "PetId" });
            DropIndex("dbo.PetsPetOwners", new[] { "PetOwnerId" });
            DropIndex("dbo.PetsPetOwners", new[] { "PetId" });
            DropIndex("dbo.OwnersWalkers", new[] { "PetWalkerId" });
            DropIndex("dbo.OwnersWalkers", new[] { "PetOwnerId" });
            DropTable("dbo.PetsPetWalkers");
            DropTable("dbo.PetsPetOwners");
            DropTable("dbo.PetWalkers");
            DropTable("dbo.Pets");
            DropTable("dbo.PetOwners");
            DropTable("dbo.OwnersWalkers");
        }
    }
}
