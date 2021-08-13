using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace BOI.Models
{
    public partial class BOIModelContext : DbContext
    {
        public BOIModelContext()
            : base("name=BOIModel")
        {
        }

        public virtual DbSet<AccountMaster> AccountMasters { get; set; }
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<Beneficiary> Beneficiaries { get; set; }
        public virtual DbSet<BranchTable> BranchTables { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<NewAcc> NewAccs { get; set; }
        public virtual DbSet<TransTable> TransTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<AccountMaster>()
                .Property(e => e.AccNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AccountMaster>()
                .Property(e => e.AccHolder)
                .IsUnicode(false);

            modelBuilder.Entity<AccountMaster>()
                .Property(e => e.IFSCCode)
                .IsUnicode(false);

            modelBuilder.Entity<AccountMaster>()
                .Property(e => e.AccType)
                .IsUnicode(false);

            modelBuilder.Entity<AccountMaster>()
                .Property(e => e.AccStatus)
                .IsUnicode(false);

            modelBuilder.Entity<AccountMaster>()
                .Property(e => e.CustId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AccountMaster>()
                .HasMany(e => e.Beneficiaries)
                .WithRequired(e => e.AccountMaster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdminLogin>()
                .Property(e => e.UserId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Beneficiary>()
                .Property(e => e.AccNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Beneficiary>()
                .Property(e => e.BenAccNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Beneficiary>()
                .Property(e => e.BenName)
                .IsUnicode(false);

            modelBuilder.Entity<Beneficiary>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<Beneficiary>()
                .Property(e => e.BenBankName)
                .IsUnicode(false);

            modelBuilder.Entity<Beneficiary>()
                .Property(e => e.IFSCCode)
                .IsUnicode(false);

            modelBuilder.Entity<Beneficiary>()
                .Property(e => e.BeneficiaryID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Beneficiary>()
                .Property(e => e.BeneficiaryType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Beneficiary>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<BranchTable>()
                .Property(e => e.IFSCCode)
                .IsUnicode(false);

            modelBuilder.Entity<BranchTable>()
                .Property(e => e.BranchName)
                .IsUnicode(false);

            modelBuilder.Entity<BranchTable>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<BranchTable>()
                .Property(e => e.BranchCode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BranchTable>()
                .HasMany(e => e.AccountMasters)
                .WithRequired(e => e.BranchTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.UserId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Login>()
                .Property(e => e.CustId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.CustId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.Fname)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.Lname)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.Phone)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.PAN)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.Aadhar)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.ResAdd)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.BranchName)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.Pincode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.PerAdd)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.PerAdd1)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.City01)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.pincode01)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.state01)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.Occupation)
                .IsUnicode(false);

            modelBuilder.Entity<NewAcc>()
                .Property(e => e.Income)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NewAcc>()
                .HasMany(e => e.AccountMasters)
                .WithRequired(e => e.NewAcc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NewAcc>()
                .HasMany(e => e.Logins)
                .WithRequired(e => e.NewAcc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransTable>()
                .Property(e => e.AccNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransTable>()
                .Property(e => e.FromAccNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransTable>()
                .Property(e => e.ToAccNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransTable>()
                .Property(e => e.BeneficiaryID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransTable>()
                .Property(e => e.Amount)
                .HasPrecision(10, 4);

            modelBuilder.Entity<TransTable>()
                .Property(e => e.TransType)
                .IsUnicode(false);

            modelBuilder.Entity<TransTable>()
                .Property(e => e.TransactionID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransTable>()
                .Property(e => e.Remarks)
                .IsUnicode(false);
        }
           public virtual ObjectResult<GetAcStatement_Result> GetAcStatement(Nullable<decimal> userId, Nullable<System.DateTime> transDate1, Nullable<System.DateTime> transDate2)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(decimal));

            var transDate1Parameter = transDate1.HasValue ?
                new ObjectParameter("TransDate1", transDate1) :
                new ObjectParameter("TransDate1", typeof(System.DateTime));

            var transDate2Parameter = transDate2.HasValue ?
                new ObjectParameter("TransDate2", transDate2) :
                new ObjectParameter("TransDate2", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAcStatement_Result>("GetAcStatement", userIdParameter, transDate1Parameter, transDate2Parameter);
        }

        public virtual ObjectResult<GetAcSummary_Result> GetAcSummary(Nullable<decimal> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(decimal));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAcSummary_Result>("GetAcSummary", userIdParameter);
        }

        public virtual ObjectResult<GetBranchDetails_Result> GetBranchDetails(Nullable<decimal> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(decimal));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBranchDetails_Result>("GetBranchDetails", userIdParameter);
        }

        public virtual ObjectResult<string> GetEmail(Nullable<decimal> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(decimal));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetEmail", userIdParameter);
        }

        public virtual ObjectResult<string> GetEmail2(Nullable<decimal> accNo)
        {
            var accNoParameter = accNo.HasValue ?
                new ObjectParameter("AccNo", accNo) :
                new ObjectParameter("AccNo", typeof(decimal));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetEmail2", accNoParameter);
        }

        public virtual ObjectResult<Nullable<int>> LoginCheck(Nullable<decimal> userId, string pwd)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(decimal));

            var pwdParameter = pwd != null ?
                new ObjectParameter("Pwd", pwd) :
                new ObjectParameter("Pwd", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("LoginCheck", userIdParameter, pwdParameter);
        }

        public virtual ObjectResult<MailingDet_Result> MailingDet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MailingDet_Result>("MailingDet");
        }

        public virtual ObjectResult<TransDetails_Result> TransDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TransDetails_Result>("TransDetails");
        }

        public virtual int UpdatePwd(Nullable<decimal> userId, string newpwd)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(decimal));

            var newpwdParameter = newpwd != null ?
                new ObjectParameter("newpwd", newpwd) :
                new ObjectParameter("newpwd", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePwd", userIdParameter, newpwdParameter);
        }

        public virtual ObjectResult<Nullable<decimal>> ValidIdVerify(Nullable<decimal> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(decimal));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("ValidIdVerify", userIdParameter);
        }

        public virtual ObjectResult<ViewCustomer_List_Result> ViewCustomer_List(string branchName)
        {
            var branchNameParameter = branchName != null ?
                new ObjectParameter("BranchName", branchName) :
                new ObjectParameter("BranchName", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ViewCustomer_List_Result>("ViewCustomer_List", branchNameParameter);
        }

        public virtual ObjectResult<ViewUserDetails_Result> ViewUserDetails(Nullable<decimal> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(decimal));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ViewUserDetails_Result>("ViewUserDetails", userIdParameter);
        }
    }
}

   