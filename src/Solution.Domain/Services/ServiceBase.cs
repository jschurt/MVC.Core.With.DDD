using Solution.Domain.Interfaces.Repositories;
using Solution.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        } //constructor

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        } //Add

        public void Dispose()
        {
            _repository.Dispose();
        } //Dispose

        public IEnumerable<TEntity> GetAll(bool eager = false)
        {
            return _repository.GetAll(eager);
        } //GetAll

        public TEntity GetById(long id)
        {
            return _repository.GetById(id);
        } //GetById

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        } //Remove

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        } //Update

    } //class
} //namespace
