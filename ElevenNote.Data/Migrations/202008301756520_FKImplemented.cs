namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKImplemented : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropPrimaryKey("dbo.Category");
            DropColumn("dbo.Category", "CategoryId");
            AddColumn("dbo.Category", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Note", "CategoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Category", "Id");
            CreateIndex("dbo.Note", "CategoryId");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "CategoryId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Category");
            DropColumn("dbo.Note", "CategoryId");
            DropColumn("dbo.Category", "Id");
            AddPrimaryKey("dbo.Category", "CategoryId");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
        }
    }
}
