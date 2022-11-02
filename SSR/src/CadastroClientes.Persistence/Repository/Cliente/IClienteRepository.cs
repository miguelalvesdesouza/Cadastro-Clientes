using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroClientes.Domain;
using CadastroClientes.Persistence.Repository;

namespace CadastroClientes.Persistence
{
    public interface IClienteRepository : IGeralRepository<Cliente>
    {
        
    }
}