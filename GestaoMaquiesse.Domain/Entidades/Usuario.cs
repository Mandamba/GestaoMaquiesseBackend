using System;
using System.Collections.Generic;
using GestaoMaquiesse.Core.Excecoes;
using GestaoMaquiesse.Domain.Validador;

namespace GestaoMaquiesse.Domain.Entidades
{
    public class Usuario : Base
    {
      public string Nome { get; private set; }
      public string Email { get; private set; }
      public string PalavraPasse { get; private set; }
        protected Usuario(){}
       public Usuario(string nome, string email, string palavraPasse)
        {
            Nome = nome;
            Email = email;
            PalavraPasse = palavraPasse;
            _erros = new List<string>();
            Validar();
        }
      public void AlterarNome(string nome){
        Nome = nome;
        Validar();
      }
      public void AlterarEmail(string email){
        Email = email;
        Validar();
      }
      public void AlterarPalavraPasse(string palavraPasse){
        PalavraPasse = palavraPasse;
        Validar();
      }

        public override bool Validar()
        {
            var validador = new ValidadorUsuario();
            var validacao = validador.Validate(this);

            if(!validacao.IsValid){

                foreach (var erro in validacao.Errors)
                    _erros.Add(erro.ErrorMessage);

                throw new ExcecoesDominio("Alguns Campos estão inválidos, por favor corrija-os!", _erros);
            }
            return true;
        }
    }
}