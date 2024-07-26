using Core.Entities;
using Core.Constants;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repistories.Base
{
    public class Repistory<T> : IRepistory<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbTable;
        public Repistory(AppDbContext context)
        {
            _context = context;
            _dbTable = _context.Set<T>();
        }
        public void Add(T item)
        {
            
            _dbTable.Add(item);
        }

        public void Delete(T item)
        {
            _dbTable.Remove(item);
        }

        public T Get(int id)
        {
            return _dbTable.Find(id);
        }

        public List<T> GetAll()
        {
            return _dbTable.ToList<T>();
        }

        public void Update(T item)
        {
            _dbTable.Update(item);
        }

        
    }
}
