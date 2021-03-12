using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Entities;
using backend.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        protected DbSet<T> _dataset;

        public Repository(DataContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public void Add(T entity)
        {
            try
            {
                entity.CreateAt = DateTime.UtcNow;
                _dataset.Add(entity);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(T entity)
        {
            try
            {
                var result = _dataset.SingleOrDefault(t => t.Id == entity.Id);
                if (result is null)
                    return;

                entity.UpdateAt = DateTime.UtcNow;
                entity.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(entity);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(int id)
        {
            var result = _dataset.SingleOrDefault(t => t.Id == id);
            if (result is null)
                return false;

            var removedItem = result;
            removedItem.Removed = true;
            _context.Entry(result).CurrentValues.SetValues(removedItem);
            _context.SaveChanges();
            return true;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public T Select(int id)
        {
            try
            {
                return _dataset.SingleOrDefault(t => t.Id == id);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> Select()
        {
            try
            {
                return _dataset;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
