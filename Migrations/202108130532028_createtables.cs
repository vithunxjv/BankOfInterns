namespace BOI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountMaster",
                c => new
                    {
                        AccNo = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        AccHolder = c.String(nullable: false, maxLength: 30, unicode: false),
                        IFSCCode = c.String(nullable: false, maxLength: 50, unicode: false),
                        AccType = c.String(maxLength: 10, unicode: false),
                        AccOpenDate = c.DateTime(storeType: "date"),
                        AccBalance = c.Int(nullable: false),
                        AccStatus = c.String(maxLength: 10, unicode: false),
                        CustId = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.AccNo)
                .ForeignKey("dbo.BranchTable", t => t.IFSCCode)
                .ForeignKey("dbo.NewAcc", t => t.CustId)
                .Index(t => t.IFSCCode)
                .Index(t => t.CustId);
            
            CreateTable(
                "dbo.Beneficiary",
                c => new
                    {
                        BeneficiaryID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        AccNo = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        BenAccNo = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        BenName = c.String(nullable: false, maxLength: 50, unicode: false),
                        NickName = c.String(maxLength: 50, unicode: false),
                        BenBankName = c.String(nullable: false, maxLength: 10, unicode: false),
                        IFSCCode = c.String(nullable: false, maxLength: 50, unicode: false),
                        BeneficiaryType = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        Remarks = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.BeneficiaryID)
                .ForeignKey("dbo.AccountMaster", t => t.AccNo)
                .Index(t => t.AccNo);
            
            CreateTable(
                "dbo.TransTable",
                c => new
                    {
                        TransactionID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        AccNo = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        FromAccNo = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        ToAccNo = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        BeneficiaryID = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        Amount = c.Decimal(storeType: "smallmoney"),
                        TransDate = c.DateTime(storeType: "date"),
                        TransTime = c.Time(precision: 7),
                        TransType = c.String(maxLength: 50, unicode: false),
                        Remarks = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.AccountMaster", t => t.AccNo)
                .ForeignKey("dbo.Beneficiary", t => t.BeneficiaryID)
                .Index(t => t.AccNo)
                .Index(t => t.BeneficiaryID);
            
            CreateTable(
                "dbo.BranchTable",
                c => new
                    {
                        IFSCCode = c.String(nullable: false, maxLength: 50, unicode: false),
                        BranchName = c.String(nullable: false, maxLength: 50, unicode: false),
                        City = c.String(nullable: false, maxLength: 50, unicode: false),
                        BranchCode = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.IFSCCode);
            
            CreateTable(
                "dbo.NewAcc",
                c => new
                    {
                        CustId = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Title = c.String(nullable: false, maxLength: 10, unicode: false),
                        Fname = c.String(nullable: false, maxLength: 50, unicode: false),
                        Lname = c.String(nullable: false, maxLength: 50, unicode: false),
                        Phone = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        Email = c.String(nullable: false, maxLength: 50),
                        PAN = c.String(nullable: false, maxLength: 20, unicode: false),
                        Aadhar = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        DOB = c.DateTime(nullable: false, storeType: "date"),
                        ResAdd = c.String(nullable: false, maxLength: 50, unicode: false),
                        BranchName = c.String(nullable: false, maxLength: 50, unicode: false),
                        City = c.String(nullable: false, maxLength: 50, unicode: false),
                        Pincode = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        State = c.String(nullable: false, maxLength: 50, unicode: false),
                        PerAdd = c.String(nullable: false, maxLength: 50, unicode: false),
                        PerAdd1 = c.String(nullable: false, maxLength: 50, unicode: false),
                        City01 = c.String(nullable: false, maxLength: 50, unicode: false),
                        pincode01 = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        state01 = c.String(nullable: false, maxLength: 50, unicode: false),
                        Gender = c.String(nullable: false, maxLength: 10, unicode: false),
                        Occupation = c.String(nullable: false, maxLength: 50, unicode: false),
                        Income = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.CustId);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        UserId = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        Pwd = c.String(nullable: false),
                        CustId = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        LoginErrorMsg = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.NewAcc", t => t.CustId)
                .Index(t => t.CustId);
            
            CreateTable(
                "dbo.AdminLogin",
                c => new
                    {
                        UserId = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        Pwd = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Login", "CustId", "dbo.NewAcc");
            DropForeignKey("dbo.AccountMaster", "CustId", "dbo.NewAcc");
            DropForeignKey("dbo.AccountMaster", "IFSCCode", "dbo.BranchTable");
            DropForeignKey("dbo.Beneficiary", "AccNo", "dbo.AccountMaster");
            DropForeignKey("dbo.TransTable", "BeneficiaryID", "dbo.Beneficiary");
            DropForeignKey("dbo.TransTable", "AccNo", "dbo.AccountMaster");
            DropIndex("dbo.Login", new[] { "CustId" });
            DropIndex("dbo.TransTable", new[] { "BeneficiaryID" });
            DropIndex("dbo.TransTable", new[] { "AccNo" });
            DropIndex("dbo.Beneficiary", new[] { "AccNo" });
            DropIndex("dbo.AccountMaster", new[] { "CustId" });
            DropIndex("dbo.AccountMaster", new[] { "IFSCCode" });
            DropTable("dbo.AdminLogin");
            DropTable("dbo.Login");
            DropTable("dbo.NewAcc");
            DropTable("dbo.BranchTable");
            DropTable("dbo.TransTable");
            DropTable("dbo.Beneficiary");
            DropTable("dbo.AccountMaster");
        }
    }
}
