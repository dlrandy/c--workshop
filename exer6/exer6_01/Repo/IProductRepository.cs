using System.Collections.Generic;
using exer6_01.GlobalFactory2021;


namespace Exer06.Repo
{
    public interface IProductRepository
    {
        int Create(Product product);
        void Delete(int id);
        void Update(Product product);
        IEnumerable<Product> Get();
    }
}