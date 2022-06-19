using System.Threading.Tasks;
using GestaoMaquiesse.Services.DTO;
using AutoMapper;
using GestaoMaquiesse.Domain.Entidades;
using GestaoMaquiesse.Core.Excecoes;
using GestaoMaquiesse.Services.Interfaces;
using GestaoMaquiesse.Infra.Interfaces;
using System.Collections.Generic;

namespace GestaoMaquiesse.Services.Services
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IMapper _mapeador;
        private readonly IRepositorioUsuario _respositorioUsuario;

        public ServicoUsuario(IMapper mapeador, IRepositorioUsuario respositorioUsuario)
        {
            _mapeador = mapeador;
            _respositorioUsuario = respositorioUsuario;
        }

        public async Task<UsuarioDTO> Criar(UsuarioDTO usuarioDto){

            var verificaExistenciaUsuario = await _respositorioUsuario.ObterPeloEmail(usuarioDto.Email);
            if(verificaExistenciaUsuario != null)
                throw new ExcecoesDominio("Já existe um usuário cadastrado com este email");
            var usuario = _mapeador.Map<Usuario>(usuarioDto);
            usuario.Validar();
            var usuarioCriado = _respositorioUsuario.Criar(usuario);
            return _mapeador.Map<UsuarioDTO>(usuario);
        }
        public async Task<UsuarioDTO> Atualizar(UsuarioDTO usuarioDto)
        {
            var usuarioExiste = await _respositorioUsuario.Obter(usuarioDto.Id);
            if(usuarioExiste == null)
                throw new ExcecoesDominio("Não existe um usuário com o identificador Informado");
            var usuario = _mapeador.Map<Usuario>(usuarioDto);
            usuario.Validar();

            var usuarioAtualizado = await _respositorioUsuario.Atualizar(usuario);

            return _mapeador.Map<UsuarioDTO>(usuarioAtualizado);
        }
        public async Task Deletar(long id)
        {
            await _respositorioUsuario.Deletar(id);
        }

        public async Task<List<UsuarioDTO>> Listar(UsuarioDTO usuarioDTO)
        {
            var todosUsuarios = await _respositorioUsuario.Listar();

            return _mapeador.Map<List<UsuarioDTO>>(todosUsuarios);
        }

        public async Task<UsuarioDTO> Obter(long id)
        {
            var usuario = await _respositorioUsuario.Obter(id);

            return _mapeador.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> ObterPeloEmail(string email)
        {
            var usuario = await _respositorioUsuario.ObterPeloEmail(email);

            return _mapeador.Map<UsuarioDTO>(usuario);
        }

        public async Task<List<UsuarioDTO>> PesquisarUsuarioPeloEmail(string email)
        {
           var todosUsuarios = await _respositorioUsuario.PesquisarUsuarioPeloEmail(email);
           
           return _mapeador.Map<List<UsuarioDTO>>(todosUsuarios);
        }

        public async Task<List<UsuarioDTO>> PesquisarUsuarioPeloNome(string nome)
        {
            var todosUsuarios = await _respositorioUsuario.PesquisarUsuarioPeloNome(nome);

            return _mapeador.Map<List<UsuarioDTO>>(todosUsuarios);
        }
    }

}