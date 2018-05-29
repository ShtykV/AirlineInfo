namespace AirlineInfo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AirlineModel : DbContext
    {
        public AirlineModel()
            : base("name=AirlineModel")
        {
        }

        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .Property(e => e.terminal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.fare)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.Passenger)
                .WithRequired(e => e.Flight)
                .HasForeignKey(e => e.Flight_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
