using Microsoft.EntityFrameworkCore;
using Solution.Domain.Interfaces.Repositories;
using Solution.Infraestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution.Infraestructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {

        protected SolutionContext _context;

        public RepositoryBase(SolutionContext context)
        {
            _context = context;
        } //constructor

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        } //Add

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<TEntity> GetAll(bool eager = false)
        {

            var query = _context.Set<TEntity>().AsQueryable();
            if (eager)
            {
                foreach (var property in _context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);
            }
            return query;

        } //GetAll

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        } //Update

    } //class
} //namespace
