using System.Collections.Generic;
using exer6_01.GlobalFactory2021;

namespace Exer06.Repo
{
    public interface IManufacturerRepository
    {
        int Create(Manufacturer Manufacturer);
        void Delete(int id);
        void Update(Manufacturer Manufacturer);
        IEnumerable<Manufacturer> Get();
    }
}