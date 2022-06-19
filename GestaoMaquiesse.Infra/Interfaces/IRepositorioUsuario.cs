using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoMaquiesse.Domain.Entidades;
namespace GestaoMaquiesse.Infra.Interfaces
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
         Task<Usuario> ObterPeloEmail(string email);
         Task<List<Usuario>> PesquisarUsuarioPeloEmail(string email);
         Task<List<Usuario>> PesquisarUsuarioPeloNome(string nome);
    }
}