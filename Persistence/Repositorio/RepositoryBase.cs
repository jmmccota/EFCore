using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositorio
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly LibraryContext Db;

        public RepositoryBase(LibraryContext ctx)
        {
            Db = ctx;
        }

        public int TotalRegistros(TEntity entidadeEntity)
        {
            return Db.Set<TEntity>().Count();
        }

        public IList<TEntity> ObterTodos()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IList<TEntity> ObterTodosOrdenacaoAscendente(string campo)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> ObterTodosOrdenacaoDescendente(string campo)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity ObterPorId(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual TEntity ObterPorId(string id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void ExcluirPorId(int id)
        {
            var entidade = Db.Set<TEntity>().Find(id);
            Db.Set<TEntity>().Remove(entidade);
            Db.SaveChanges();
        }

        public void Excluir(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Remove(entidadeEntity);
            Db.SaveChanges();
        }

        public void ExcluirLista(IList<TEntity> entidadeEntity)
        {
            foreach (var Entity in entidadeEntity)
            {
                Db.Set<TEntity>().Remove(Entity);
            }
            Db.SaveChanges();
        }

        public void Salvar(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Add(entidadeEntity);
            Db.SaveChanges();
        }

        public void SalvarLista(IList<TEntity> entidadeEntity)
        {
            foreach (var Entity in entidadeEntity)
            {
                Db.Set<TEntity>().Add(Entity);
            }
            Db.SaveChanges();
        }

        public void Atualiza(TEntity entidadeEntity)
        {
            Db.Entry(entidadeEntity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void AtualizaLista(IList<TEntity> entidadesEntity)
        {
            foreach (var Entity in entidadesEntity)
            {
                Db.Entry(Entity).State = EntityState.Modified;
            }

            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
