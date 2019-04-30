namespace PurchaseReqV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "PurchaseReqV3.Budget",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Type = c.String(maxLength: 50),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateEnded = c.DateTime(),
                        StateContract = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PurchaseReqV3.Campus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 100),
                        CollegeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PurchaseReqV3.College", t => t.CollegeId)
                .Index(t => t.CollegeId);
            
            CreateTable(
                "PurchaseReqV3.College",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CollegeName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PurchaseReqV3.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserId = c.String(maxLength: 128),
                        DivisionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PurchaseReq.Division", t => t.DivisionId)
                .ForeignKey("PurchaseReq.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
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
                "PurchaseReq.Division",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PurchaseReq.User", t => t.UserId)
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
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "PurchaseReq.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 500),
                        ActualPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PurchaseReq.JobRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DateHired = c.DateTime(nullable: false),
                        DateTerminated = c.DateTime(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PurchaseReq.PurchaseRequisition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CalculatedTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Justification = c.String(maxLength: 500),
                        Approver_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PurchaseReq.User", t => t.Approver_Id)
                .Index(t => t.Approver_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserBudgetCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        BudgetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PurchaseReqV3.Budget", t => t.BudgetId, cascadeDelete: true)
                .ForeignKey("PurchaseReq.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.BudgetId);
            
            CreateTable(
                "PurchaseReq.Vendor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Phone = c.String(),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PurchaseReq.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Division_Id = c.Int(),
                        Division_Id1 = c.Int(),
                        Department_Id = c.Int(),
                        F_name = c.String(maxLength: 30),
                        L_name = c.String(maxLength: 30),
                        Address = c.String(maxLength: 100),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("PurchaseReq.Division", t => t.Division_Id)
                .ForeignKey("PurchaseReq.Division", t => t.Division_Id1)
                .ForeignKey("PurchaseReqV3.Department", t => t.Department_Id)
                .ForeignKey("PurchaseReqV3.Department", t => t.DepartmentId)
                .Index(t => t.Id)
                .Index(t => t.Division_Id)
                .Index(t => t.Division_Id1)
                .Index(t => t.Department_Id)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("PurchaseReq.User", "DepartmentId", "PurchaseReqV3.Department");
            DropForeignKey("PurchaseReq.User", "Department_Id", "PurchaseReqV3.Department");
            DropForeignKey("PurchaseReq.User", "Division_Id1", "PurchaseReq.Division");
            DropForeignKey("PurchaseReq.User", "Division_Id", "PurchaseReq.Division");
            DropForeignKey("PurchaseReq.User", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserBudgetCodes", "UserId", "PurchaseReq.User");
            DropForeignKey("dbo.UserBudgetCodes", "BudgetId", "PurchaseReqV3.Budget");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("PurchaseReq.PurchaseRequisition", "Approver_Id", "PurchaseReq.User");
            DropForeignKey("PurchaseReqV3.Department", "UserId", "PurchaseReq.User");
            DropForeignKey("PurchaseReq.Division", "UserId", "PurchaseReq.User");
            DropForeignKey("PurchaseReqV3.Department", "DivisionId", "PurchaseReq.Division");
            DropForeignKey("PurchaseReqV3.Campus", "CollegeId", "PurchaseReqV3.College");
            DropIndex("PurchaseReq.User", new[] { "DepartmentId" });
            DropIndex("PurchaseReq.User", new[] { "Department_Id" });
            DropIndex("PurchaseReq.User", new[] { "Division_Id1" });
            DropIndex("PurchaseReq.User", new[] { "Division_Id" });
            DropIndex("PurchaseReq.User", new[] { "Id" });
            DropIndex("dbo.UserBudgetCodes", new[] { "BudgetId" });
            DropIndex("dbo.UserBudgetCodes", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("PurchaseReq.PurchaseRequisition", new[] { "Approver_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("PurchaseReq.Division", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("PurchaseReqV3.Department", new[] { "DivisionId" });
            DropIndex("PurchaseReqV3.Department", new[] { "UserId" });
            DropIndex("PurchaseReqV3.Campus", new[] { "CollegeId" });
            DropTable("PurchaseReq.User");
            DropTable("PurchaseReq.Vendor");
            DropTable("dbo.UserBudgetCodes");
            DropTable("dbo.AspNetRoles");
            DropTable("PurchaseReq.PurchaseRequisition");
            DropTable("PurchaseReq.JobRole");
            DropTable("PurchaseReq.Item");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("PurchaseReq.Division");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("PurchaseReqV3.Department");
            DropTable("PurchaseReqV3.College");
            DropTable("PurchaseReqV3.Campus");
            DropTable("PurchaseReqV3.Budget");
        }
    }
}
