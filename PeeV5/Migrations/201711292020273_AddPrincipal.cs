namespace PeeV5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrincipal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        IdCourse = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Credits = c.Int(nullable: false),
                        IdCycle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCourse)
                .ForeignKey("dbo.Cycles", t => t.IdCycle, cascadeDelete: true)
                .Index(t => t.IdCycle);
            
            CreateTable(
                "dbo.Cycles",
                c => new
                    {
                        IdCycle = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        IdTeacher = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCycle)
                .ForeignKey("dbo.Teachers", t => t.IdTeacher, cascadeDelete: true)
                .Index(t => t.IdTeacher);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        IdTeacher = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Last_Name = c.String(),
                        Specialty = c.String(),
                        Email = c.String(),
                        pass = c.String(),
                        IdPrincipal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTeacher)
                .ForeignKey("dbo.Principals", t => t.IdPrincipal, cascadeDelete: true)
                .Index(t => t.IdPrincipal);
            
            CreateTable(
                "dbo.Principals",
                c => new
                    {
                        IdPrincipal = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Last_Name = c.String(),
                        Address = c.String(),
                        DNI = c.Int(nullable: false),
                        email = c.String(),
                        pass = c.String(),
                        Job_tittle = c.String(),
                        IdPlace = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPrincipal)
                .ForeignKey("dbo.Places", t => t.IdPlace, cascadeDelete: true)
                .Index(t => t.IdPlace);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        IdStudent = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Pass = c.String(),
                        IdPlace = c.Int(nullable: false),
                        IdCycle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdStudent)
                .ForeignKey("dbo.Cycles", t => t.IdCycle, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.IdPlace, cascadeDelete: true)
                .Index(t => t.IdPlace)
                .Index(t => t.IdCycle);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "IdPlace", "dbo.Places");
            DropForeignKey("dbo.Students", "IdCycle", "dbo.Cycles");
            DropForeignKey("dbo.Cycles", "IdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "IdPrincipal", "dbo.Principals");
            DropForeignKey("dbo.Principals", "IdPlace", "dbo.Places");
            DropForeignKey("dbo.Courses", "IdCycle", "dbo.Cycles");
            DropIndex("dbo.Students", new[] { "IdCycle" });
            DropIndex("dbo.Students", new[] { "IdPlace" });
            DropIndex("dbo.Principals", new[] { "IdPlace" });
            DropIndex("dbo.Teachers", new[] { "IdPrincipal" });
            DropIndex("dbo.Cycles", new[] { "IdTeacher" });
            DropIndex("dbo.Courses", new[] { "IdCycle" });
            DropTable("dbo.Students");
            DropTable("dbo.Principals");
            DropTable("dbo.Teachers");
            DropTable("dbo.Cycles");
            DropTable("dbo.Courses");
        }
    }
}
