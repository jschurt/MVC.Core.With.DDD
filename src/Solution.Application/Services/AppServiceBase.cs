using Solution.Application.Interfaces;
using Solution.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Solution.Application.Services
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        protected readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        } //constructor

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        } //Add

        public void Dispose()
        {
            _serviceBase.Dispose();
        } //Dispose

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        } //GetAll

        public TEntity GetById(long id)
        {
            return _serviceBase.GetById(id);
        } //GetById

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        } //Remove

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        } //Update
    } //class
} //namespace
