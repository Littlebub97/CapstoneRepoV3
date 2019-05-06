namespace PurchaseReqV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "PurchaseReq.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Street = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PurchaseReqV3.Campus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        AddressId = c.Int(),
                        CollegeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PurchaseReq.Address", t => t.AddressId)
                .ForeignKey("PurchaseReqV3.College", t => t.CollegeId)
                .Index(t => t.AddressId)
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
                "PurchaseReq.Vendor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Phone = c.String(),
                        ItemId = c.Int(nullable: false),
                        StateContract = c.Boolean(nullable: false),
                        AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PurchaseReq.Address", t => t.AddressId)
                .ForeignKey("PurchaseReq.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "PurchaseReq.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 500),
                        ActualPrice = c.Decimal(precision: 18, scale: 2),
                        PurchaseRequisitionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PurchaseReq.PurchaseRequisition", t => t.PurchaseRequisitionId)
                .Index(t => t.PurchaseRequisitionId);
            
            CreateTable(
                "PurchaseReq.PurchaseRequisition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Justification = c.String(maxLength: 500),
                        ApprovalStatus = c.Int(nullable: false),
                        Approver_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PurchaseReq.User", t => t.Approver_Id)
                .ForeignKey("PurchaseReq.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Approver_Id);
            
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
                "PurchaseReqV3.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserId = c.String(maxLength: 128),
                        DivisionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PurchaseReq.User", t => t.UserId)
                .ForeignKey("PurchaseReq.Division", t => t.DivisionId)
                .Index(t => t.UserId)
                .Index(t => t.DivisionId);
            
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
                "PurchaseReqV3.Budget",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Type = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateEnded = c.DateTime(),
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
                "PurchaseReq.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Division_Id = c.Int(),
                        Department_Id = c.Int(),
                        Division_Id1 = c.Int(),
                        User_Id = c.String(maxLength: 128),
                        F_name = c.String(maxLength: 30),
                        L_name = c.String(maxLength: 30),
                        Address = c.String(maxLength: 100),
                        Active = c.Boolean(nullable: false),
                        DateHired = c.DateTime(nullable: false),
                        DateTerminated = c.DateTime(),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("PurchaseReq.Division", t => t.Division_Id)
                .ForeignKey("PurchaseReqV3.Department", t => t.Department_Id)
                .ForeignKey("PurchaseReq.Division", t => t.Division_Id1)
                .ForeignKey("PurchaseReq.User", t => t.User_Id)
                .ForeignKey("PurchaseReqV3.Department", t => t.DepartmentId)
                .Index(t => t.Id)
                .Index(t => t.Division_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.Division_Id1)
                .Index(t => t.User_Id)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("PurchaseReq.User", "DepartmentId", "PurchaseReqV3.Department");
            DropForeignKey("PurchaseReq.User", "User_Id", "PurchaseReq.User");
            DropForeignKey("PurchaseReq.User", "Division_Id1", "PurchaseReq.Division");
            DropForeignKey("PurchaseReq.User", "Department_Id", "PurchaseReqV3.Department");
            DropForeignKey("PurchaseReq.User", "Division_Id", "PurchaseReq.Division");
            DropForeignKey("PurchaseReq.User", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserBudgetCodes", "UserId", "PurchaseReq.User");
            DropForeignKey("dbo.UserBudgetCodes", "BudgetId", "PurchaseReqV3.Budget");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("PurchaseReq.Vendor", "ItemId", "PurchaseReq.Item");
            DropForeignKey("PurchaseReq.PurchaseRequisition", "UserId", "PurchaseReq.User");
            DropForeignKey("PurchaseReq.Item", "PurchaseRequisitionId", "PurchaseReq.PurchaseRequisition");
            DropForeignKey("PurchaseReq.PurchaseRequisition", "Approver_Id", "PurchaseReq.User");
            DropForeignKey("PurchaseReq.Division", "UserId", "PurchaseReq.User");
            DropForeignKey("PurchaseReqV3.Department", "DivisionId", "PurchaseReq.Division");
            DropForeignKey("PurchaseReqV3.Department", "UserId", "PurchaseReq.User");
            DropForeignKey("PurchaseReq.Vendor", "AddressId", "PurchaseReq.Address");
            DropForeignKey("PurchaseReqV3.Campus", "CollegeId", "PurchaseReqV3.College");
            DropForeignKey("PurchaseReqV3.Campus", "AddressId", "PurchaseReq.Address");
            DropIndex("PurchaseReq.User", new[] { "DepartmentId" });
            DropIndex("PurchaseReq.User", new[] { "User_Id" });
            DropIndex("PurchaseReq.User", new[] { "Division_Id1" });
            DropIndex("PurchaseReq.User", new[] { "Department_Id" });
            DropIndex("PurchaseReq.User", new[] { "Division_Id" });
            DropIndex("PurchaseReq.User", new[] { "Id" });
            DropIndex("dbo.UserBudgetCodes", new[] { "BudgetId" });
            DropIndex("dbo.UserBudgetCodes", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("PurchaseReq.Division", new[] { "UserId" });
            DropIndex("PurchaseReqV3.Department", new[] { "DivisionId" });
            DropIndex("PurchaseReqV3.Department", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("PurchaseReq.PurchaseRequisition", new[] { "Approver_Id" });
            DropIndex("PurchaseReq.PurchaseRequisition", new[] { "UserId" });
            DropIndex("PurchaseReq.Item", new[] { "PurchaseRequisitionId" });
            DropIndex("PurchaseReq.Vendor", new[] { "AddressId" });
            DropIndex("PurchaseReq.Vendor", new[] { "ItemId" });
            DropIndex("PurchaseReqV3.Campus", new[] { "CollegeId" });
            DropIndex("PurchaseReqV3.Campus", new[] { "AddressId" });
            DropTable("PurchaseReq.User");
            DropTable("dbo.UserBudgetCodes");
            DropTable("dbo.AspNetRoles");
            DropTable("PurchaseReq.JobRole");
            DropTable("PurchaseReqV3.Budget");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("PurchaseReq.Division");
            DropTable("PurchaseReqV3.Department");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("PurchaseReq.PurchaseRequisition");
            DropTable("PurchaseReq.Item");
            DropTable("PurchaseReq.Vendor");
            DropTable("PurchaseReqV3.College");
            DropTable("PurchaseReqV3.Campus");
            DropTable("PurchaseReq.Address");
        }
    }
}
