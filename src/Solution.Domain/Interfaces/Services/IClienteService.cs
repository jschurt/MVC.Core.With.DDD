using Solution.Domain.Entities;
using System.Collections.Generic;

namespace Solution.Domain.Interfaces.Services
{
    public interface IClienteService: IServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> Clientes);

    } //interface
} //namespace
