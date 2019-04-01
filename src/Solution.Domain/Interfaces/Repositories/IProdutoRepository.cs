using Solution.Domain.Entities;
using System.Collections.Generic;

namespace Solution.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {

        IEnumerable<Produto> BuscarPorNome(string nome);

    } //class
} //namespace
