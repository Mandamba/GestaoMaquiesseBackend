using System;
using System.Collections.Generic;

namespace GestaoMaquiesse.Core.Excecoes
{
    public class ExcecoesDominio : Exception
    {
        internal List<string> _erros;
        public IReadOnlyCollection<string> Erros => _erros;

        public ExcecoesDominio(){}
        public ExcecoesDominio(string mensagem, List<string> erros) : base(mensagem){
            _erros = erros;
        }
        public ExcecoesDominio(string mensagem) : base(mensagem){

        }
        public ExcecoesDominio(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna){}
    }
}