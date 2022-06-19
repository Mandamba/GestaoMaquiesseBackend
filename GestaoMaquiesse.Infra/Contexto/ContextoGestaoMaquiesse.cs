using GestaoMaquiesse.Domain.Entidades;
using GestaoMaquiesse.Infra.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace GestaoMaquiesse.Infra.Contexto
{
    public class ContextoGestaoMaquiesse : DbContext
    {
        public ContextoGestaoMaquiesse(){}
        public ContextoGestaoMaquiesse(DbContextOptions<ContextoGestaoMaquiesse> options) : base(options){}

        public virtual DbSet<Usuario> Usuarios{get;set;}

        protected override void OnModelCreating(ModelBuilder builder){

            builder.ApplyConfiguration(new UsuarioMap());
        }
    }
}