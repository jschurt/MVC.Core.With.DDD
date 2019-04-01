using Solution.Domain.Entities;
using Solution.Domain.Interfaces.Repositories;
using Solution.Infraestructure.Data.Context;

namespace Solution.Infraestructure.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {

        public ClienteRepository(SolutionContext context ): base(context)
        { } //constructor

    } //class
} //namespace
