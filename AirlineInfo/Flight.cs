namespace AirlineInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Flight")]
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            Passenger = new HashSet<Passenger>();
        }

        public int Id { get; set; }

        public DateTime arrival_time { get; set; }

        public DateTime departure_time { get; set; }

        [Required]
        public string airport_arrival { get; set; }

        [Required]
        public string airport_departure { get; set; }

        [Required]
        [StringLength(10)]
        public string terminal { get; set; }

        [Required]
        public string type { get; set; }

        [Required]
        [StringLength(20)]
        public string flight_status { get; set; }

        [Column(TypeName = "money")]
        public decimal fare { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passenger> Passenger { get; set; }

    }
}
