using BGF.App.Core.Entities;
using BGF.App.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
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
                entity.Name = entity.Name;
            }
            var updatedEntity = _dbContext.Update(entityInDb);
            await _dbContext.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task<IEnumerable<Boardgame>> GetAll()
        {
            var boardgames = _dbContext.BoardGames.ToList();

            return boardgames.OrderBy(e => e.Name);
        }

        public async Task<List<Boardgame>> GetUsersBoardgames(string username)
        {
            var userWithBoardgames = _dbContext.Users
                .Include(e => e.BoardGames)
                .ThenInclude(row => row.Boardgame)
                .FirstOrDefault(e => e.UserName == username);

            if (userWithBoardgames == null)
            {
                throw new NullReferenceException($"No user found on username {username}");
            }

            var boardgames = userWithBoardgames.BoardGames.Select(row => row.Boardgame).ToList();

            return boardgames;
        }
    }
}
