namespace HospitalCW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SpecializationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Age = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStart = c.String(),
                        TimeEnd = c.String(),
                        SpecialistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Age = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        SpecializationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        IsRegistrar = c.Boolean(nullable: false),
                        Doctor_Id = c.Int(),
                        Pat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialists", t => t.Doctor_Id)
                .ForeignKey("dbo.Patients", t => t.Pat_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Pat_Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitDate = c.DateTime(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        SpecialistId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DiagnosisId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Pat_Id", "dbo.Patients");
            DropForeignKey("dbo.Users", "Doctor_Id", "dbo.Specialists");
            DropIndex("dbo.Users", new[] { "Pat_Id" });
            DropIndex("dbo.Users", new[] { "Doctor_Id" });
            DropTable("dbo.Visits");
            DropTable("dbo.Users");
            DropTable("dbo.Specializations");
            DropTable("dbo.Specialists");
            DropTable("dbo.Schedules");
            DropTable("dbo.Patients");
            DropTable("dbo.Diagnosis");
        }
    }
}
