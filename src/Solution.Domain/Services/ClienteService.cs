using Solution.Domain.Entities;
using Solution.Domain.Interfaces.Repositories;
using Solution.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {

        public ClienteService(IClienteRepository repository) : base(repository)
        { } //constructor

        public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> Clientes)
        {
            return Clientes.Where(c => c.ClienteEspecial(c));
        }
    } //class

} //namespace
