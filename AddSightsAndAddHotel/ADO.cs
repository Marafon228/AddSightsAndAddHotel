using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AddSightsAndAddHotel
{
    public partial class ADO : DbContext
    {
        public ADO()
            : base("name=ADO")
        {
        }
        private static ADO _instance;
        public static ADO Instance
        {
            get { return _instance ?? (_instance = new ADO()); }
        }

        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelComment> HotelComment { get; set; }
        public virtual DbSet<Sights> Sights { get; set; }
        public virtual DbSet<SightsComment> SightsComment { get; set; }
        public virtual DbSet<SightsReservation> SightsReservation { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.HotelComment)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HotelComment>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Sights>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Sights>()
                .HasMany(e => e.SightsComment)
                .WithRequired(e => e.Sights)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sights>()
                .HasMany(e => e.SightsReservation)
                .WithRequired(e => e.Sights)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SightsComment>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<SightsReservation>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
