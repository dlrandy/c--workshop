using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exer06.activity{
     [Table("Person", Schema = "TruckLogistics")]
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        public DateTime DoB { get; set; }
    }
}