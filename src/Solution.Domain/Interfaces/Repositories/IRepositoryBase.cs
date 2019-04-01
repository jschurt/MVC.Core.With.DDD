using System.Collections.Generic;

namespace Solution.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {

        void Add(TEntity obj);

        TEntity GetById(long id);

        IEnumerable<TEntity> GetAll(bool eager = false);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();

    } //interface
} //namespace
