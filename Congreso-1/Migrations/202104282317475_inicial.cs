namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Webinars", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Webinars", new[] { "UserId" });
            AddColumn("dbo.Congresses", "CongressBanner", c => c.String());
            AddColumn("dbo.Congresses", "CongressColorA", c => c.String());
            AddColumn("dbo.Congresses", "CongressColorB", c => c.String());
            AddColumn("dbo.Stands", "StandName", c => c.String());
            AddColumn("dbo.Digital_Resource", "Index", c => c.Int(nullable: false));
            AddColumn("dbo.Webinars", "WebinarBannerPrincipal", c => c.String());
            AddColumn("dbo.Webinars", "WebinarImagen", c => c.String());
            AddColumn("dbo.Webinars", "LinkWebinar", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Rol", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "Available", c => c.Boolean(nullable: false));
            DropColumn("dbo.Webinars", "UserCount");
            DropColumn("dbo.Webinars", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Webinars", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Webinars", "UserCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "Available", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Rol");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Webinars", "LinkWebinar");
            DropColumn("dbo.Webinars", "WebinarImagen");
            DropColumn("dbo.Webinars", "WebinarBannerPrincipal");
            DropColumn("dbo.Digital_Resource", "Index");
            DropColumn("dbo.Stands", "StandName");
            DropColumn("dbo.Congresses", "CongressColorB");
            DropColumn("dbo.Congresses", "CongressColorA");
            DropColumn("dbo.Congresses", "CongressBanner");
            CreateIndex("dbo.Webinars", "UserId");
            AddForeignKey("dbo.Webinars", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
