namespace HotelReservations.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Stars = c.Short(nullable: false),
                        Address = c.String(),
                        Zip = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        City_Id = c.Guid(nullable: false),
                        Country_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .Index(t => t.Stars)
                .Index(t => t.IsDeleted)
                .Index(t => t.City_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.PhotoUrls",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Url = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        Hotel_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Hotel_Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        Hotel_Id = c.Guid(),
                        RoomType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id)
                .ForeignKey("dbo.RoomTypes", t => t.RoomType_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.IsDeleted)
                .Index(t => t.Hotel_Id)
                .Index(t => t.RoomType_Id);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        MainBeds = c.Short(nullable: false),
                        AdditionalBeds = c.Short(nullable: false),
                        HasBathTube = c.Boolean(nullable: false),
                        HasTV = c.Boolean(nullable: false),
                        HasTerrace = c.Boolean(nullable: false),
                        HasAirConditioner = c.Boolean(nullable: false),
                        HasRefrigerator = c.Boolean(nullable: false),
                        HasHairDryer = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.PricePeriods",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        WeekendPercent = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        PriceGroup_Id = c.Guid(nullable: false),
                        RoomType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceGroups", t => t.PriceGroup_Id, cascadeDelete: true)
                .ForeignKey("dbo.RoomTypes", t => t.RoomType_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.PriceGroup_Id)
                .Index(t => t.RoomType_Id);
            
            CreateTable(
                "dbo.PriceGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        PerAdditionalBed_Id = c.Guid(),
                        PerChildBed_Id = c.Guid(),
                        PerMainBed_Id = c.Guid(),
                        PerRoom_Id = c.Guid(),
                        RoomType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceSets", t => t.PerAdditionalBed_Id)
                .ForeignKey("dbo.PriceSets", t => t.PerChildBed_Id)
                .ForeignKey("dbo.PriceSets", t => t.PerMainBed_Id)
                .ForeignKey("dbo.PriceSets", t => t.PerRoom_Id)
                .ForeignKey("dbo.RoomTypes", t => t.RoomType_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.PerAdditionalBed_Id)
                .Index(t => t.PerChildBed_Id)
                .Index(t => t.PerMainBed_Id)
                .Index(t => t.PerRoom_Id)
                .Index(t => t.RoomType_Id);
            
            CreateTable(
                "dbo.PriceSets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BedOnly = c.Double(),
                        BB = c.Double(),
                        HB = c.Double(),
                        FB = c.Double(),
                        AllInclusive = c.Double(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AdultsNumber = c.Short(nullable: false),
                        ChildrenNumber = c.Short(nullable: false),
                        MealPlan = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        Hotel_Id = c.Guid(),
                        Room_Id = c.Guid(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Hotel_Id)
                .Index(t => t.Room_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Reservations", "Hotel_Id", "dbo.Hotels");
            DropForeignKey("dbo.Rooms", "RoomType_Id", "dbo.RoomTypes");
            DropForeignKey("dbo.PricePeriods", "RoomType_Id", "dbo.RoomTypes");
            DropForeignKey("dbo.PricePeriods", "PriceGroup_Id", "dbo.PriceGroups");
            DropForeignKey("dbo.PriceGroups", "RoomType_Id", "dbo.RoomTypes");
            DropForeignKey("dbo.PriceGroups", "PerRoom_Id", "dbo.PriceSets");
            DropForeignKey("dbo.PriceGroups", "PerMainBed_Id", "dbo.PriceSets");
            DropForeignKey("dbo.PriceGroups", "PerChildBed_Id", "dbo.PriceSets");
            DropForeignKey("dbo.PriceGroups", "PerAdditionalBed_Id", "dbo.PriceSets");
            DropForeignKey("dbo.Rooms", "Hotel_Id", "dbo.Hotels");
            DropForeignKey("dbo.PhotoUrls", "Hotel_Id", "dbo.Hotels");
            DropForeignKey("dbo.Hotels", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Hotels", "City_Id", "dbo.Cities");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "IsDeleted" });
            DropIndex("dbo.Reservations", new[] { "User_Id" });
            DropIndex("dbo.Reservations", new[] { "Room_Id" });
            DropIndex("dbo.Reservations", new[] { "Hotel_Id" });
            DropIndex("dbo.Reservations", new[] { "IsDeleted" });
            DropIndex("dbo.PriceSets", new[] { "IsDeleted" });
            DropIndex("dbo.PriceGroups", new[] { "RoomType_Id" });
            DropIndex("dbo.PriceGroups", new[] { "PerRoom_Id" });
            DropIndex("dbo.PriceGroups", new[] { "PerMainBed_Id" });
            DropIndex("dbo.PriceGroups", new[] { "PerChildBed_Id" });
            DropIndex("dbo.PriceGroups", new[] { "PerAdditionalBed_Id" });
            DropIndex("dbo.PriceGroups", new[] { "IsDeleted" });
            DropIndex("dbo.PricePeriods", new[] { "RoomType_Id" });
            DropIndex("dbo.PricePeriods", new[] { "PriceGroup_Id" });
            DropIndex("dbo.PricePeriods", new[] { "IsDeleted" });
            DropIndex("dbo.RoomTypes", new[] { "IsDeleted" });
            DropIndex("dbo.Rooms", new[] { "RoomType_Id" });
            DropIndex("dbo.Rooms", new[] { "Hotel_Id" });
            DropIndex("dbo.Rooms", new[] { "IsDeleted" });
            DropIndex("dbo.Rooms", new[] { "Name" });
            DropIndex("dbo.PhotoUrls", new[] { "Hotel_Id" });
            DropIndex("dbo.PhotoUrls", new[] { "IsDeleted" });
            DropIndex("dbo.Hotels", new[] { "Country_Id" });
            DropIndex("dbo.Hotels", new[] { "City_Id" });
            DropIndex("dbo.Hotels", new[] { "IsDeleted" });
            DropIndex("dbo.Hotels", new[] { "Stars" });
            DropIndex("dbo.Countries", new[] { "IsDeleted" });
            DropIndex("dbo.Countries", new[] { "Name" });
            DropIndex("dbo.Cities", new[] { "IsDeleted" });
            DropIndex("dbo.Cities", new[] { "Name" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Reservations");
            DropTable("dbo.PriceSets");
            DropTable("dbo.PriceGroups");
            DropTable("dbo.PricePeriods");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.PhotoUrls");
            DropTable("dbo.Hotels");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
