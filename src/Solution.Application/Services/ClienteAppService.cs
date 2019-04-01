using Solution.Application.Interfaces;
using Solution.Domain.Entities;
using Solution.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Application.Services
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {

        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clientService) : base(clientService)
        {
            _clienteService = clientService;
        } //constructor

        public IEnumerable<Cliente> ObterClientesEspecias()
        {
            return _clienteService.ObterClientesEspeciais(_clienteService.GetAll());
        }
    }
}
