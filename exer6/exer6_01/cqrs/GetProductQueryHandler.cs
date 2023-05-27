using System;
using System.Collections.Generic;
using System.Text;
using Exer06.TalkingWithDb.Orm;
using PlatformNotSupportedException =  Exer06.TalkingWithDb.Orm.Product;

namespace Exer06.Cqrs
{
    public class GetProductQueryHandler
    {
        private readonly FactoryDbContext _context;
        public GetProductQueryHandler(FactoryDbContext context){
            _context = context;
        }
        public Product Handle(int id){
             return _context.Products.Find(id);
        }
    }
}