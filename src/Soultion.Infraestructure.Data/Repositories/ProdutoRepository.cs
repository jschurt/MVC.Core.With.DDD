using System.Collections.Generic;
using System.Linq;
using Solution.Domain.Entities;
using Solution.Domain.Interfaces.Repositories;
using Solution.Infraestructure.Data.Context;

namespace Solution.Infraestructure.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {

        public ProdutoRepository(SolutionContext context) : base(context)
        {
        } //constructor

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _context.Produtos.Where(p => p.Nome == nome);
        } //BuscarPorNome

    } //class
} //namespace
