using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CadastroClientes.Domain;
using Dapper;

namespace CadastroClientes.Persistence
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection dbConnection;

        public ClienteRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        public Cliente Create(Cliente cliente)
        {
            string query = 
            @"INSERT INTO [Cadastros].[dbo].[Cliente]
            (
                [Nome]
                ,[Telefone]
                ,[Endereco]
                ,[Data]
            ) 
            VALUES
            (
                @Nome
                ,@Telefone
                ,@Endereco
                ,@Data
            );
            SELECT @@IDENTITY;";

            cliente.IdCliente = dbConnection.ExecuteScalar<int>(query, cliente);
            return cliente;
            
        }

        public IEnumerable<Cliente> GetAll()
        {
            return dbConnection.Query<Cliente>(
                @"SELECT 
                     [IdCliente] as IdCliente
                    ,[Nome] as Nome
                    ,[Telefone] as Telefone
                    ,[Endereco] as Endereco
                    ,[Data] as Data
                FROM [Cadastros].[dbo].[Cliente]
                "
            );
        }

        public Cliente? GetById(int id)
        {
            return dbConnection.Query<Cliente>(
                @$"SELECT 
                     [IdCliente] as IdCliente
                    ,[Nome] as Nome
                    ,[Telefone] as Telefone
                    ,[Endereco] as Endereco
                    ,[Data] as Data
                FROM [Cadastros].[dbo].[Cliente]
                WHERE IdCliente = {id}
                "
            ).FirstOrDefault();
        }

        public Cliente Remove(int id)
        {
            return dbConnection.Query<Cliente>( 
            @$"DELETE 
            FROM [Cadastros].[dbo].[Cliente]
            WHERE idCliente = {id};
            ").FirstOrDefault();

            
        }   

        public Cliente Update(Cliente cliente)
        {
            string query = 
            @"UPDATE [Cadastros].[dbo].[Cliente]
                SET
                    Nome = @Nome,
                    Telefone = @Telefone,
                    Endereco = @Endereco,
                    Data = @Data
                WHERE IdCliente = @IdCliente";
            
            dbConnection.Execute(query, cliente);
            return cliente;
        }
    }
}