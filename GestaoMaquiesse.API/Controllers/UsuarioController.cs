using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GestaoMaquiesse.API.Utilities;
using GestaoMaquiesse.API.ViewModels;
using GestaoMaquiesse.Core.Excecoes;
using GestaoMaquiesse.Infra.Interfaces;
using GestaoMaquiesse.Services.DTO;
using GestaoMaquiesse.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoMaquiesse.API.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicoUsuario _servicoUsuario;
        private readonly IMapper _mapeador;
        public UsuarioController(IServicoUsuario servicoUsuario, IMapper mapeador)
        {
            _servicoUsuario = servicoUsuario;
            _mapeador = mapeador;
        }

        [HttpPost]
        [Route("api/v1/usuarios/criar")]
        public async Task<IActionResult> Criar([FromBody]ViewModelCriarUsuario usuarioViewModel){
            try
            {
                var usuarioDto = _mapeador.Map<UsuarioDTO>(usuarioViewModel);
                var usuarioCriado = await _servicoUsuario.Criar(usuarioDto);

                return Ok( new ResultadoModelView {
                    Mensagem = "Usuário Criado com Sucesso !!! ",
                    Sucesso = true,
                    Dados = usuarioCriado
                });
            }
            catch (ExcecoesDominio ex)
            {
                return BadRequest(Responses.MensagemDeErroDeDominio(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                 return StatusCode(500, Responses.MensagemDeErroNaAplicacao());
            }
        }
        [HttpPut]
        [Route("api/v1/usuarios/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody]UsuarioDTO usuaioDto)
        {
            try
            {
                var usuarioAtualizado = await _servicoUsuario.Atualizar(usuaioDto);

                return Ok( new ResultadoModelView{
                    Mensagem = "Usuário Atualizado com sucesso!",
                    Sucesso = true,
                    Dados = usuarioAtualizado
                });
            }
            catch (ExcecoesDominio ex)
            {
                return BadRequest(Responses.MensagemDeErroDeDominio(ex.Message, ex.Erros));
            }
            catch(Exception){
                return StatusCode(500, Responses.MensagemDeErroNaAplicacao());
            }
        }
    }
}