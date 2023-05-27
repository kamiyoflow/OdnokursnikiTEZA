using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Common.Exceptions;
using TEZAProject.Dal.Interfaces;
using TEZAProject.Domain;

namespace TEZAProject.Dal.Repositories
{
     public class Repository : IRepository
     {

          private readonly TEZAProjectDbContext _tezaProjectDbContext;
          private readonly IMapper _mapper;

          public Repository(TEZAProjectDbContext tezaProjectDbContext, IMapper mapper)
          {
               _tezaProjectDbContext = tezaProjectDbContext;
               _mapper = mapper;
          }

          public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
          {
               _tezaProjectDbContext.Set<TEntity>().Add(entity);
          }

          public async Task Delete<TEntity>(int id) where TEntity : BaseEntity
          {
               var entity = await _tezaProjectDbContext.Set<TEntity>().FindAsync(id);
               if (entity == null)
               {
                    throw new ValidationException($"Object of type {typeof(TEntity)} with id { id } not found");
               }

               _tezaProjectDbContext.Set<TEntity>().Remove(entity);
          }

          public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity
          {
               return await _tezaProjectDbContext.Set<TEntity>().ToListAsync();
          }

          public async Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity
          {
               return await _tezaProjectDbContext.FindAsync<TEntity>(id);
          }

          public async Task SaveChangesAsync()
          {
               await _tezaProjectDbContext.SaveChangesAsync();
          }

          public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity
          {
              _tezaProjectDbContext.Update(entity);
          }
     }
}
