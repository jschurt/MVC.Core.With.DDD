using Solution.Domain.Entities;
using System.Collections.Generic;

namespace Solution.Application.Interfaces
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {

        IEnumerable<Produto> BuscaPorNome(string nome);

    } //interface
} //namespace
