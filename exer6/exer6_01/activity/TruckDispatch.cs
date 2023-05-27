using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exer06.activity
{
    [Table("TruckDispatch", Schema = "TruckLogistics")]
    public class TruckDispatch
    {
        public int Id { get; set; }
        public Truck Truck { get; set; }
        public Person Driver { get; set; }
        public int DriverId { get; set; }
        public int TruckId { get; set; }
        [MaxLength(200)]
        public string CurrentLocation { get; set; }
        public DateTime Deadline { get; set; }
    }
}