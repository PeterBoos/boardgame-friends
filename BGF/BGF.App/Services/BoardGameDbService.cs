using BGF.App.Core.Entities;
using BGF.App.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Services
{
    public class BoardGameDbService : IDbServiceBase<Boardgame>
    {
        private readonly ApplicationDbContext _dbContext;
        public BoardGameDbService(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<EntityEntry<Boardgame>> Create(Boardgame entity)
        {
            var addedEntity =_dbContext.BoardGames.Add(entity);
            await _dbContext.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<EntityEntry<Boardgame>> Delete(Boardgame entity)
        {
            var deletedEntity =_dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return deletedEntity;
        }


        public async Task<EntityEntry<Boardgame>> Update(Boardgame entity)
        {
            var entityInDb = _dbContext.BoardGames.FirstOrDefault(item => item.Id == entity.Id);
            if (entityInDb != null)
            {
                entityInDb.Description = entity.Description;
                entity.Title = entity.Title;
            }
            var updatedEntity = _dbContext.Update(entityInDb);
            await _dbContext.SaveChangesAsync();
            return updatedEntity;
        }
        public async Task<IEnumerable<Boardgame>> GetAll()
        {

            // TODO: use dbcontext to get boardgame list
            var bgList = new List<Boardgame>();
            return bgList;
        }
    }
}
