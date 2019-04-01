using Solution.Domain.Entities;
using Solution.Domain.Interfaces.Repositories;
using Solution.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {

        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
            _repository = repository;
        } //constructor

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _repository.BuscarPorNome(nome);
        }
    } //class
} //namespace
