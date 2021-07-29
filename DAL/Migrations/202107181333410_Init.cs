namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Flights", "AirplaneId", "dbo.Airplanes");
            DropForeignKey("dbo.Flights", "ArrivalCityId", "dbo.Cities");
            DropForeignKey("dbo.FlightClients", "Flight_Number", "dbo.Flights");
            DropForeignKey("dbo.FlightClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Flights", "DispatchCityId", "dbo.Cities");
            DropForeignKey("dbo.Airplanes", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Airplanes", "TypeId", "dbo.Types");
            DropIndex("dbo.Airplanes", new[] { "CountryId" });
            DropIndex("dbo.Airplanes", new[] { "TypeId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Flights", new[] { "DispatchCityId" });
            DropIndex("dbo.Flights", new[] { "ArrivalCityId" });
            DropIndex("dbo.Flights", new[] { "AirplaneId" });
            DropIndex("dbo.FlightClients", new[] { "Flight_Number" });
            DropIndex("dbo.FlightClients", new[] { "Client_Id" });
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ArtishId = c.Int(nullable: false),
                        Year = c.DateTime(nullable: false),
                        GanreId = c.Int(nullable: false),
                        AuditionNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ganres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Rating = c.Double(),
                        AuditionNumber = c.Int(nullable: false),
                        Text = c.String(),
                        Name = c.String(),
                        Playlist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlists", t => t.Playlist_Id)
                .Index(t => t.Playlist_Id);
            
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false));
            DropTable("dbo.Airplanes");
            DropTable("dbo.Cities");
            DropTable("dbo.Flights");
            DropTable("dbo.Clients");
            DropTable("dbo.Types");
            DropTable("dbo.FlightClients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FlightClients",
                c => new
                    {
                        Flight_Number = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Flight_Number, t.Client_Id });
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        CreditCard = c.String(),
                        Phone = c.String(maxLength: 30),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Number = c.Int(nullable: false, identity: true),
                        DepartureTime = c.DateTime(nullable: false),
                        DispatchCityId = c.Int(nullable: false),
                        ArrivalCityId = c.Int(nullable: false),
                        AirplaneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Number);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Airplanes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 100),
                        MaxPassengers = c.Int(nullable: false),
                        CountryId = c.Int(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Tracks", "Playlist_Id", "dbo.Playlists");
            DropIndex("dbo.Tracks", new[] { "Playlist_Id" });
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 100));
            DropTable("dbo.Tracks");
            DropTable("dbo.Playlists");
            DropTable("dbo.Ganres");
            DropTable("dbo.Categories");
            DropTable("dbo.Artishes");
            DropTable("dbo.Albums");
            CreateIndex("dbo.FlightClients", "Client_Id");
            CreateIndex("dbo.FlightClients", "Flight_Number");
            CreateIndex("dbo.Flights", "AirplaneId");
            CreateIndex("dbo.Flights", "ArrivalCityId");
            CreateIndex("dbo.Flights", "DispatchCityId");
            CreateIndex("dbo.Cities", "CountryId");
            CreateIndex("dbo.Airplanes", "TypeId");
            CreateIndex("dbo.Airplanes", "CountryId");
            AddForeignKey("dbo.Airplanes", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Airplanes", "CountryId", "dbo.Countries", "Id");
            AddForeignKey("dbo.Flights", "DispatchCityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.FlightClients", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FlightClients", "Flight_Number", "dbo.Flights", "Number", cascadeDelete: true);
            AddForeignKey("dbo.Flights", "ArrivalCityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.Flights", "AirplaneId", "dbo.Airplanes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
