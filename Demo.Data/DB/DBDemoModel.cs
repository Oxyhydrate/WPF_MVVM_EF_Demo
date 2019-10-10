namespace Demo.Data.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBDemoModel : DbContext
    {
        public DBDemoModel()
            : base("name=DBDemoModel")
        {
        }

        //����������� ����������� DBDemoModel ����� ���������� ������ � ConnectionString
        public DBDemoModel(string pass)
        : base("name=DBDemoModel")
        {

            this.Database.Connection.ConnectionString = this.Database.Connection.ConnectionString.Replace("mypassword", pass);

        }

        public virtual DbSet<ABONENTS> ABONENTS { get; set; }
        public virtual DbSet<BILLS> BILLS { get; set; }
        public virtual DbSet<COMMENTS> COMMENTS { get; set; }
        public virtual DbSet<CONTACTS> CONTACTS { get; set; }
        public virtual DbSet<NUMBERS> NUMBERS { get; set; }
        public virtual DbSet<SR_BANK> SR_BANK { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.KOD_SUBSCRIBE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.OWNER)
                .IsUnicode(false);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.KOD_STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.R_ACCOUNT)
                .IsUnicode(false);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.OKPO)
                .IsUnicode(false);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.OGRN)
                .IsUnicode(false);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.OKVED)
                .IsUnicode(false);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.LEGAL_ADDRESS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.PHISIC_ADDRESS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.DIRECTOR)
                .IsUnicode(false);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.GLAVBUH)
                .IsUnicode(false);

            modelBuilder.Entity<ABONENTS>()
                .Property(e => e.GOS_CONTRACT_STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BILLS>()
                .Property(e => e.BAN)
                .IsUnicode(false);

            modelBuilder.Entity<BILLS>()
                .Property(e => e.BILL)
                .IsUnicode(false);

            modelBuilder.Entity<BILLS>()
                .Property(e => e.SUMM)
                .HasPrecision(10, 2);

            modelBuilder.Entity<BILLS>()
                .Property(e => e.ORDER_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COMMENTS>()
                .Property(e => e.KOD_SUBSCRIBE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COMMENTS>()
                .Property(e => e.COMM)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.REGION)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.PLACETYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.PLACENAME)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.STREETTYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.STREETNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.HOUSE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.FLAT)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.TELEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.CONTACTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACTS>()
                .Property(e => e.KOD_SUBSCRIBE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<NUMBERS>()
                .Property(e => e.KOD_SUBSCRIBE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<NUMBERS>()
                .Property(e => e.BAN)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBERS>()
                .Property(e => e.MSISDN)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBERS>()
                .Property(e => e.SIM)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBERS>()
                .Property(e => e.TARIFF)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBERS>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SR_BANK>()
                .Property(e => e.BIK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SR_BANK>()
                .Property(e => e.BANK_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SR_BANK>()
                .Property(e => e.K_ACCOUNT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SR_BANK>()
                .Property(e => e.TOWN_NAME)
                .IsUnicode(false);
        }
    }
}