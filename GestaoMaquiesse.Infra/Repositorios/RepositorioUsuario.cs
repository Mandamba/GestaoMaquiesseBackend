using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoMaquiesse.Domain.Entidades;
using GestaoMaquiesse.Infra.Interfaces;
using GestaoMaquiesse.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoMaquiesse.Infra.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario{
        private readonly ContextoGestaoMaquiesse _contexto;
        public RepositorioUsuario(ContextoGestaoMaquiesse contexto) : base(contexto){
            _contexto = contexto;
        }

        public virtual async Task<Usuario> ObterPeloEmail(string email){
            var usuarios = await _contexto.Usuarios
                        .Where
                        (
                            x =>
                                 x.Email.ToLower() == email.ToLower()
                        )
                        .AsNoTracking()
                        .ToListAsync();


            return usuarios.FirstOrDefault();
        }

        public virtual async Task<List<Usuario>> PesquisarUsuarioPeloEmail(string email){
            var usuarios = await _contexto.Usuarios
                        .Where
                        (
                            x =>
                                 x.Email.ToLower().Contains(email.ToLower())
                        )
                        .AsNoTracking()
                        .ToListAsync();


            return usuarios;
        }
        public virtual async Task<List<Usuario>> PesquisarUsuarioPeloNome(string nome){
            var usuarios = await _contexto.Usuarios
                        .Where
                        (
                            x =>
                                 x.Nome.ToLower().Contains(nome.ToLower())
                        )
                        .AsNoTracking()
                        .ToListAsync();


            return usuarios;
        }
    }
}