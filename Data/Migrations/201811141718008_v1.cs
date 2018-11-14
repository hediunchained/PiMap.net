namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application_Lettre",
                c => new
                    {
                        ApplicationID = c.Int(nullable: false, identity: true),
                        State = c.String(),
                        Date = c.String(),
                        Specialty = c.String(),
                        Resume = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CustomRole_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.CustomRole_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Mandate",
                c => new
                    {
                        MandateID = c.Int(nullable: false, identity: true),
                        MandateStart_Date = c.DateTime(nullable: false),
                        MandateFinish_Date = c.DateTime(nullable: false),
                        State = c.String(),
                        ProjetID = c.Int(),
                        RessourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MandateID)
                .ForeignKey("dbo.Projet", t => t.ProjetID)
                .Index(t => t.ProjetID);
            
            CreateTable(
                "dbo.Projet",
                c => new
                    {
                        ProjetID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Start_Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        Adresse = c.String(),
                        Total_Ressource_nb = c.Int(nullable: false),
                        Levio_ressource_nb = c.Int(nullable: false),
                        PictureURL = c.String(),
                        ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjetID);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        MessageType = c.String(),
                        Target = c.String(),
                        Object = c.String(),
                        Read = c.Boolean(nullable: false),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
            CreateTable(
                "dbo.Organiational_chart",
                c => new
                    {
                        OrganizationalId = c.Int(nullable: false, identity: true),
                        Level = c.String(),
                        Program_Name = c.String(),
                        Leader_Name = c.String(),
                        Project_Name = c.String(),
                        Client_Name = c.String(),
                        AccountManager = c.String(),
                        Assignment_Manager_Name = c.String(),
                    })
                .PrimaryKey(t => t.OrganizationalId);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        Requirements = c.String(),
                        YearsExperience = c.Int(nullable: false),
                        Education = c.String(),
                        Price = c.Int(nullable: false),
                        Deposit_Date = c.DateTime(nullable: false),
                        Deposit_hour = c.DateTime(nullable: false),
                        Mandatestart_date = c.DateTime(nullable: false),
                        MandateFinish_date = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        Project_ProjetID = c.Int(),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Projet", t => t.Project_ProjetID)
                .Index(t => t.Project_ProjetID);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ClientType = c.String(),
                        Category = c.String(),
                        logoURL = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Ressource",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RessourceID = c.Int(nullable: false),
                        ContractType = c.String(),
                        Seniority = c.String(),
                        SkillSet = c.String(),
                        Notes = c.String(),
                        Resume = c.String(),
                        PictureURL = c.String(),
                        state = c.String(),
                        StartHoliday = c.DateTime(nullable: false),
                        EndHoliday = c.DateTime(nullable: false),
                        OrganizationalId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .ForeignKey("dbo.Ressource", t => t.RessourceID)
                .ForeignKey("dbo.Organiational_chart", t => t.OrganizationalId)
                .Index(t => t.Id)
                .Index(t => t.RessourceID)
                .Index(t => t.OrganizationalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ressource", "OrganizationalId", "dbo.Organiational_chart");
            DropForeignKey("dbo.Ressource", "RessourceID", "dbo.Ressource");
            DropForeignKey("dbo.Ressource", "Id", "dbo.Users");
            DropForeignKey("dbo.Client", "Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserRoles", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserLogins", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserClaims", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Request", "Project_ProjetID", "dbo.Projet");
            DropForeignKey("dbo.Mandate", "ProjetID", "dbo.Projet");
            DropIndex("dbo.Ressource", new[] { "OrganizationalId" });
            DropIndex("dbo.Ressource", new[] { "RessourceID" });
            DropIndex("dbo.Ressource", new[] { "Id" });
            DropIndex("dbo.Client", new[] { "Id" });
            DropIndex("dbo.Request", new[] { "Project_ProjetID" });
            DropIndex("dbo.Mandate", new[] { "ProjetID" });
            DropIndex("dbo.CustomUserRoles", new[] { "Users_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "Users_Id" });
            DropIndex("dbo.CustomUserClaims", new[] { "Users_Id" });
            DropTable("dbo.Ressource");
            DropTable("dbo.Client");
            DropTable("dbo.CustomRoles");
            DropTable("dbo.Request");
            DropTable("dbo.Organiational_chart");
            DropTable("dbo.Message");
            DropTable("dbo.Projet");
            DropTable("dbo.Mandate");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Application_Lettre");
        }
    }
}
