using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Exer06.Repo;

namespace Exer06.TalkingWithDb.Orm
{
    [Table("manufacturer", Schema = "factory")]
    public class Manufacturer : IAggregate
    {
        [Column("id")]
        public int Id {get; set;}
        [Column("name")]
        public string Name {get; set;}
        [Column("country")]
        public string Country {get; set;}
 
        public virtual ICollection<Product> Products {get;set;} = new List<Product>();
    }
}