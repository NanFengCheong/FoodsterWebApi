namespace FoodsterApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInUserTagModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTagModels",
                c => new
                    {
                        UserTagID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserTagID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTagModels");
        }
    }
}
