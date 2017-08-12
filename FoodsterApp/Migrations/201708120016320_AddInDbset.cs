namespace FoodsterApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInDbset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodModels",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PriceRangeId = c.Int(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                        MealID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodID)
                .ForeignKey("dbo.MealModels", t => t.MealID, cascadeDelete: true)
                .ForeignKey("dbo.PriceRangeModels", t => t.PriceRangeId, cascadeDelete: true)
                .ForeignKey("dbo.RestaurantModels", t => t.RestaurantID, cascadeDelete: true)
                .ForeignKey("dbo.TagModels", t => t.TagID, cascadeDelete: true)
                .Index(t => t.PriceRangeId)
                .Index(t => t.RestaurantID)
                .Index(t => t.TagID)
                .Index(t => t.MealID);
            
            CreateTable(
                "dbo.MealModels",
                c => new
                    {
                        MealID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MealID);
            
            CreateTable(
                "dbo.PriceRangeModels",
                c => new
                    {
                        PriceRangeID = c.Int(nullable: false, identity: true),
                        Min = c.Int(nullable: false),
                        Max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PriceRangeID);
            
            CreateTable(
                "dbo.RestaurantModels",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        GPSLocation = c.String(),
                        OpeningHours = c.String(),
                        ContantNo = c.String(),
                        GooglePlacesID = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantID);
            
            CreateTable(
                "dbo.TagModels",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.FoodRatingModels",
                c => new
                    {
                        FoodRatingID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodRatingID)
                .ForeignKey("dbo.FoodModels", t => t.FoodID, cascadeDelete: true)
                .Index(t => t.FoodID);
            
            CreateTable(
                "dbo.PhotoModels",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        PhotoLink = c.String(),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.FoodModels", t => t.FoodID, cascadeDelete: true)
                .Index(t => t.FoodID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhotoModels", "FoodID", "dbo.FoodModels");
            DropForeignKey("dbo.FoodRatingModels", "FoodID", "dbo.FoodModels");
            DropForeignKey("dbo.FoodModels", "TagID", "dbo.TagModels");
            DropForeignKey("dbo.FoodModels", "RestaurantID", "dbo.RestaurantModels");
            DropForeignKey("dbo.FoodModels", "PriceRangeId", "dbo.PriceRangeModels");
            DropForeignKey("dbo.FoodModels", "MealID", "dbo.MealModels");
            DropIndex("dbo.PhotoModels", new[] { "FoodID" });
            DropIndex("dbo.FoodRatingModels", new[] { "FoodID" });
            DropIndex("dbo.FoodModels", new[] { "MealID" });
            DropIndex("dbo.FoodModels", new[] { "TagID" });
            DropIndex("dbo.FoodModels", new[] { "RestaurantID" });
            DropIndex("dbo.FoodModels", new[] { "PriceRangeId" });
            DropTable("dbo.PhotoModels");
            DropTable("dbo.FoodRatingModels");
            DropTable("dbo.TagModels");
            DropTable("dbo.RestaurantModels");
            DropTable("dbo.PriceRangeModels");
            DropTable("dbo.MealModels");
            DropTable("dbo.FoodModels");
        }
    }
}
