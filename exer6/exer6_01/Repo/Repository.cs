using System.Collections.Generic;
using exer6_01.GlobalFactory2021;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Exer06.Repo
{
    public class Repository<TAggregate> : IPRepository<TAggregate> where TAggregate : class, IAggregate
    {
        private readonly DbSet<TAggregate> _dbSet;
        private readonly DbContext _context;
        public Repository(DbContext context){
            _dbSet = context.Set<TAggregate>();
            _context = context;
        }
        public int Create(TAggregate aggregate)
        {
            var added = _dbSet.Add(aggregate);
            _context.SaveChanges();
            return added.Entity.Id;
        }

        public void Delete(int id)
        {
            var toRemove = _dbSet.Find(id);
            if (toRemove != null)
            {
                _dbSet.Remove(toRemove);
            }
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<TAggregate> Get()
        {
            return _dbSet.ToList();
        }

        public TAggregate Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TAggregate aggregate)
        {
            _dbSet.Update(aggregate);
            _context.SaveChanges();
        }
    }


}