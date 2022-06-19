using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoMaquiesse.Services.DTO;

namespace GestaoMaquiesse.Services.Interfaces
{
    public interface IServicoUsuario
    {
        Task<UsuarioDTO> Criar(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> Atualizar(UsuarioDTO usuarioDTO);
        Task Deletar(long id);
        Task<UsuarioDTO> Obter(long id);
        Task<List<UsuarioDTO>> Listar(UsuarioDTO usuarioDTO);
        Task<List<UsuarioDTO>> PesquisarUsuarioPeloNome(string nome);
        Task<List<UsuarioDTO>> PesquisarUsuarioPeloEmail(string email);
        Task<UsuarioDTO> ObterPeloEmail(string email);
    }
}