using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CadastroClientes.Domain;
using CadastroClientes.Persistence;

namespace CadastroClientes.Application
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteRepository clienteRepository;
        private readonly IDbConnection dbConnection;

        public ClienteService(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            clienteRepository = new ClienteRepository(dbConnection);
        }
        public Cliente Create(Cliente cliente)
        {
            return clienteRepository.Create(cliente);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return clienteRepository.GetAll();
        }

        public Cliente? GetById(int id)
        {
            return clienteRepository.GetById(id);
        }

        public Cliente Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente Update(Cliente cliente)
        {
            return clienteRepository.Update(cliente);
        }
    }
}