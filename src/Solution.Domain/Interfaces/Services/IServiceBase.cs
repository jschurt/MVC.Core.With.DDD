using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {

        void Add(TEntity obj);
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll(bool eager = false);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();

    } //interface

} //namespace
