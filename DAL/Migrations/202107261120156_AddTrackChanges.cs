namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrackChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tracks", "AlbumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tracks", "AlbumId", c => c.Int(nullable: false));
        }
    }
}
