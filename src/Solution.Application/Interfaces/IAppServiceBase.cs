using System.Collections.Generic;

namespace Solution.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {

        void Add(TEntity obj);
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();

    } //interface
} //namespace
