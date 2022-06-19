using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoMaquiesse.Domain.Entidades;
using GestaoMaquiesse.Infra.Contexto;
using GestaoMaquiesse.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoMaquiesse.Infra.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : Base
    {
        private readonly ContextoGestaoMaquiesse _contexto;
        public RepositorioBase(ContextoGestaoMaquiesse contexto){
            _contexto = contexto;
        }

        public virtual async Task<T> Criar(T obj){
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Atualizar(T obj){
            _contexto.Entry(obj).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<T> Deletar(long id){

            var obj = await Obter(id);

            if(obj != null){

                _contexto.Remove(obj);
                
                await _contexto.SaveChangesAsync();
            }
            return obj;
        }
        public virtual async Task<T> Obter(long id){
            var obj = await _contexto.Set<T>()
                                      .AsNoTracking()
                                      .Where(x=>x.Id == id)
                                      .ToListAsync();
            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Listar(){
            return await _contexto.Set<T>()
                                    .AsNoTracking()
                                    .ToListAsync();
        }
    }
}