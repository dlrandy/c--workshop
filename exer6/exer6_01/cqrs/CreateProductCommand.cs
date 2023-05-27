using System;
using System.Collections.Generic;
using System.Text;
namespace Exer06.Cqrs
{
    public class CreateProductCommand   
    {
        public string Name {get;set;}
        public decimal Price {get;set;}
        public int ManufacturerId {get;set;}
    }
}