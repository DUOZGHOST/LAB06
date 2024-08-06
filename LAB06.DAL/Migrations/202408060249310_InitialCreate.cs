namespace LAB06.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        FacultyID = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.FacultyID);
            
            CreateTable(
                "dbo.Major",
                c => new
                    {
                        MajorID = c.Int(nullable: false, identity: true),
                        FacultyID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.MajorID)
                .ForeignKey("dbo.Faculty", t => t.FacultyID)
                .Index(t => t.FacultyID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 10),
                        FullName = c.String(nullable: false, maxLength: 255),
                        AverageScore = c.Double(nullable: false),
                        FacultyID = c.Int(),
                        MajorID = c.Int(),
                        Avatar = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Faculty", t => t.FacultyID)
                .ForeignKey("dbo.Major", t => t.MajorID)
                .Index(t => t.FacultyID)
                .Index(t => t.MajorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Major", "FacultyID", "dbo.Faculty");
            DropForeignKey("dbo.Student", "MajorID", "dbo.Major");
            DropForeignKey("dbo.Student", "FacultyID", "dbo.Faculty");
            DropIndex("dbo.Student", new[] { "MajorID" });
            DropIndex("dbo.Student", new[] { "FacultyID" });
            DropIndex("dbo.Major", new[] { "FacultyID" });
            DropTable("dbo.Student");
            DropTable("dbo.Major");
            DropTable("dbo.Faculty");
        }
    }
}
