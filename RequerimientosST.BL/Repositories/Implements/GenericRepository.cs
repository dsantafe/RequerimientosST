using RequerimientosST.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace RequerimientosST.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DBContext context;
        public GenericRepository(DBContext context)
        {
            this.context = context;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Update(TEntity entity)
        {            
            context.Set<TEntity>().AddOrUpdate(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
