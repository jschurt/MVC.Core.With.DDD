using Solution.Application.Interfaces;
using Solution.Domain.Entities;
using Solution.Domain.Interfaces.Services;
using Solution.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Application.Services
{
    public class ProdutoAppService: AppServiceBase<Produto>, IProdutoAppService
    {

        public ProdutoAppService(IProdutoService produtoService) : base(produtoService)
        {
        } //constructor

        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            return (this._serviceBase as ProdutoService).BuscarPorNome(nome);
        } //BuscarPorNome

    } //class
} //namespace
