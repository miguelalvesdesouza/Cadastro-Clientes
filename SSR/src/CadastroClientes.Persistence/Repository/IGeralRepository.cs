using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClientes.Persistence.Repository
{
    public interface IGeralRepository<T>
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T Create(T item);
        T Update(T item);
        T Remove(int id);
    }
}