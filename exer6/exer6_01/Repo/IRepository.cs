using System.Collections.Generic;
using exer6_01.GlobalFactory2021;
using System;


namespace Exer06.Repo
{
    public interface IPRepository<TEntity>:IDisposable where TEntity:class
    {
        int Create(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
    }
}