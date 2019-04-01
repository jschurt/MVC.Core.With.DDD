using Solution.Domain.Entities;
using System.Collections.Generic;

namespace Solution.Application.Interfaces
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspecias();

    } //interface
} //namespace
