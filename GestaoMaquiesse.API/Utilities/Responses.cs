using System.Collections.Generic;
using GestaoMaquiesse.API.ViewModels;

namespace GestaoMaquiesse.API.Utilities
{
    public class Responses
    {
        public static ResultadoModelView MensagemDeErroNaAplicacao(){
            return new ResultadoModelView {
                Mensagem = "Ocorreu algum erro Interno na Aplicação, por favor tente novamente!",
                Sucesso = false,
                Dados = null
            };
        }

        public static ResultadoModelView MensagemDeErroDeDominio(string mensagem){
            return new ResultadoModelView{
                Mensagem = mensagem,
                Sucesso = false,
                Dados = null
            };
        }
        public static ResultadoModelView MensagemDeErroDeDominio(string mensagem, IReadOnlyCollection<string> erros){
            return new ResultadoModelView{
                Mensagem = mensagem,
                Sucesso = false,
                Dados = erros
            };
        }
        public static ResultadoModelView MensagemDeNaoAutorizacao(){
            return new ResultadoModelView {
                Mensagem = "A combinação de login e senha está incorreta!!!",
                Sucesso = false,
                Dados = null
            };
        }
    }
}