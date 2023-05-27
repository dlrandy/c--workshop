using System;
using System.Collections.Generic;
using System.Text;
using Exer06.TalkingWithDb.Orm;

namespace Exer06.Cqrs
{
    public class CreateProductCommandHandler
    {
        private readonly FactoryDbContext _context;
        public CreateProductCommandHandler(FactoryDbContext context){
            _context = context;
        }
        public int Handle(CreateProductCommand command){
            var product = new Product{
                ManufacturerId = command.ManufacturerId,
                Name = command.Name,
                Price = command.Price
            };
            var added = _context.Products.Add(product);
            _context.SaveChanges();
            return added.Entity.Id;
        }
    }
}