using Chat.Domain.Interfaces;
using Chat.Domain.Interfaces.Repository_Interfaces;
using Chat.Domain.Models;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly ChatDbContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(ChatDbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        async Task<IEnumerable<T>> IRepository<T>.GetAll()
        {
            return await this.GetAll();
        }
        async Task<T> IRepository<T>.GetById(Guid id)
        {
            return await this.GetById(id);
        }
        async Task<T> IRepository<T>.Add(T entity)
        {
            return await this.Add(entity);
        }
        async Task<T> IRepository<T>.Update(T entity)
        {
            return await this.Update(entity);
        }
        async Task IRepository<T>.Remove(T entity)
        {
            await this.Remove(entity);
        }


        protected virtual async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet
                .AsNoTracking()
                .ToListAsync();
        }
        protected virtual async Task<T> GetById(Guid id)
        {
            return await DbSet
                   .AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Id == id);
        }
        protected virtual async Task<T> Add(T entity)
        {
            var newEntity = DbSet.Add(entity);
            await Db.SaveChangesAsync();

            return newEntity.Entity;
        }
        protected virtual async Task<T> Update(T entity)
        {
            var updatedEntity = DbSet.Update(entity);
            await Db.SaveChangesAsync();

            return updatedEntity.Entity;
        }
        protected virtual async Task Remove(T entity)
        {
            DbSet.Remove(entity);
            await Db.SaveChangesAsync();
        }

        void IRepository<T>.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
