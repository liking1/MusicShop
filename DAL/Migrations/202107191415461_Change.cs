namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Albums", "ArtishId");
            CreateIndex("dbo.Albums", "GanreId");
            CreateIndex("dbo.Albums", "CategoryId");
            CreateIndex("dbo.Artishes", "CountryId");
            AddForeignKey("dbo.Albums", "ArtishId", "dbo.Artishes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Artishes", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Albums", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Albums", "GanreId", "dbo.Ganres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "GanreId", "dbo.Ganres");
            DropForeignKey("dbo.Albums", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Artishes", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Albums", "ArtishId", "dbo.Artishes");
            DropIndex("dbo.Artishes", new[] { "CountryId" });
            DropIndex("dbo.Albums", new[] { "CategoryId" });
            DropIndex("dbo.Albums", new[] { "GanreId" });
            DropIndex("dbo.Albums", new[] { "ArtishId" });
        }
    }
}
