using Solution.Domain.Entities;
using System.Collections.Generic;

namespace Solution.Domain.Interfaces.Services
{
    public interface IProdutoService: IServiceBase<Produto>
    {

        IEnumerable<Produto> BuscarPorNome(string nome);

    } //interface

} //namespace
