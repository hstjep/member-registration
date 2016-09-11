namespace MemberRegistration.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MemberId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 60),
                        Description = c.String(maxLength: 200),
                        ActivityType = c.Int(nullable: false),
                        NumberOfHours = c.Int(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 60),
                        LastName = c.String(maxLength: 60),
                        OIB = c.String(maxLength: 11, unicode: false),
                        Address = c.String(maxLength: 40),
                        Place = c.String(maxLength: 20),
                        PostalCode = c.String(maxLength: 20, unicode: false),
                        Country = c.String(maxLength: 20),
                        PdvId = c.String(maxLength: 30, unicode: false),
                        IsMember = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SocietyId = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        MaturityDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(maxLength: 30),
                        InvoiceIssuerId = c.Guid(nullable: false),
                        ResponsiblePersonId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.InvoiceIssuer", t => t.InvoiceIssuerId, cascadeDelete: true)
                .ForeignKey("dbo.ResponsiblePerson", t => t.ResponsiblePersonId, cascadeDelete: true)
                .ForeignKey("dbo.Society", t => t.SocietyId, cascadeDelete: true)
                .Index(t => t.SocietyId)
                .Index(t => t.CustomerId)
                .Index(t => t.InvoiceIssuerId)
                .Index(t => t.ResponsiblePersonId);
            
            CreateTable(
                "dbo.InvoiceIssuer",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FullName = c.String(maxLength: 35),
                        OperatorLable = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceItem",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        InvoiceId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Year = c.Int(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        CurrencyUnit = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.MembershipFee",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        InvoiceId = c.Guid(nullable: false),
                        InvoiceItemId = c.Guid(nullable: false),
                        Year = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        PaymentStatus = c.Int(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId)
                .ForeignKey("dbo.InvoiceItem", t => t.InvoiceItemId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.MemberId)
                .Index(t => t.InvoiceId)
                .Index(t => t.InvoiceItemId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
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
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        MeasuringUnit = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResponsiblePerson",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FullName = c.String(maxLength: 35),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Society",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        Acronym = c.String(maxLength: 10),
                        Address = c.String(maxLength: 40),
                        Place = c.String(maxLength: 20),
                        PostalCode = c.String(maxLength: 20, unicode: false),
                        Country = c.String(maxLength: 20),
                        OIB = c.String(maxLength: 11),
                        WebSite = c.String(maxLength: 50),
                        Email = c.String(),
                        Logo = c.Binary(),
                        MimeTypeImage = c.String(),
                        IBAN = c.String(maxLength: 70),
                        CashRegisterLocation = c.String(maxLength: 4000),
                        Bank = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MembershipNumber = c.Int(nullable: false),
                        BirthPlace = c.String(maxLength: 20),
                        BirthDate = c.DateTime(),
                        PhoneNumber = c.String(maxLength: 30, unicode: false),
                        CurrentEmployment = c.String(maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                        WebSite = c.String(maxLength: 30, unicode: false),
                        AreaOfInterest = c.String(maxLength: 140),
                        MembershipDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Members", "Id", "dbo.Customer");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Activity", "MemberId", "dbo.Customer");
            DropForeignKey("dbo.Invoice", "SocietyId", "dbo.Society");
            DropForeignKey("dbo.Invoice", "ResponsiblePersonId", "dbo.ResponsiblePerson");
            DropForeignKey("dbo.InvoiceItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.InvoiceItem", "MemberId", "dbo.Members");
            DropForeignKey("dbo.MembershipFee", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MembershipFee", "MemberId", "dbo.Members");
            DropForeignKey("dbo.MembershipFee", "InvoiceItemId", "dbo.InvoiceItem");
            DropForeignKey("dbo.MembershipFee", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.InvoiceItem", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.Invoice", "InvoiceIssuerId", "dbo.InvoiceIssuer");
            DropForeignKey("dbo.Invoice", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Members", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.MembershipFee", new[] { "User_Id" });
            DropIndex("dbo.MembershipFee", new[] { "InvoiceItemId" });
            DropIndex("dbo.MembershipFee", new[] { "InvoiceId" });
            DropIndex("dbo.MembershipFee", new[] { "MemberId" });
            DropIndex("dbo.InvoiceItem", new[] { "MemberId" });
            DropIndex("dbo.InvoiceItem", new[] { "ProductId" });
            DropIndex("dbo.InvoiceItem", new[] { "InvoiceId" });
            DropIndex("dbo.Invoice", new[] { "ResponsiblePersonId" });
            DropIndex("dbo.Invoice", new[] { "InvoiceIssuerId" });
            DropIndex("dbo.Invoice", new[] { "CustomerId" });
            DropIndex("dbo.Invoice", new[] { "SocietyId" });
            DropIndex("dbo.Activity", new[] { "MemberId" });
            DropTable("dbo.Members");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Society");
            DropTable("dbo.ResponsiblePerson");
            DropTable("dbo.Product");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.MembershipFee");
            DropTable("dbo.InvoiceItem");
            DropTable("dbo.InvoiceIssuer");
            DropTable("dbo.Invoice");
            DropTable("dbo.Customer");
            DropTable("dbo.Activity");
        }
    }
}
