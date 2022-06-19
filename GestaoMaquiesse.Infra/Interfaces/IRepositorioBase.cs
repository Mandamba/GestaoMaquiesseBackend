using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoMaquiesse.Domain.Entidades;

namespace GestaoMaquiesse.Infra.Interfaces
{
    public interface IRepositorioBase<T> where T : Base
    {
         Task<T> Criar(T obj);
         Task<T> Atualizar(T obj);
         Task<T> Deletar(long id);
         Task<T> Obter(long id);
         Task<List<T>> Listar();
    }
}