
using CC.Core.DataPersistent;
using Domain.Core.CoreData;
using Domain.Core.Interface;
using Domain.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CC.Core.Repositories
{
   public class BaseRepository<T> :  IRepository<T> where T : Entity
    {
        private AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(T item)
        {
           _context.Add(item);
            _context.SaveChanges();
           
        }

        public IQueryable<T> CreateSet()
        {
            return _context.CreateSet<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return Query();
        }

        public T GetById(int id)
        {
            return GetAll().FirstOrDefault(i => i.Id == id);
        }

        public T GetByName(string name)
        {
            return GetAll().FirstOrDefault(i => i.Name == name);
        }

        public IQueryable<T> Query()
        {
            return _context.CreateSet<T>();
        }

        public void Remove(T item)
        {
            _context.Delete(item);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var persisted = GetById(id);
            if (persisted == null)
                throw new Exception(string.Format("Illegal parameter id:{0}", id));
            Remove(persisted);
        }

        public void Update(T item)
        {
            if (item == null) return;
            _context.Attach(item).State = EntityState.Modified;
             _context.SaveChanges();             
        }

    }
}
