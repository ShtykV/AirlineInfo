namespace AirlineInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Passenger")]
    public partial class Passenger
    {
        public int Id { get; set; }

        [Required]
        public string full_name { get; set; }

        [Required]
        public string nationality { get; set; }

        [Required]
        public string passport { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_of_birth { get; set; }

        [Required]
        public string sex { get; set; }

        [Column("class")]
        [Required]
        public string _class { get; set; }

        public int seat { get; set; }

        public int Flight_Id { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
