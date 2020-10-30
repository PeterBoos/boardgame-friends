using BGF.App.Core.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Services
{
    public class GameSessionDbService : IDbServiceBase<GameSession>
    {
        public Task<EntityEntry<GameSession>> Create(GameSession entity)
        {
            throw new NotImplementedException();
        }

        public Task<EntityEntry<GameSession>> Delete(GameSession entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameSession>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EntityEntry<GameSession>> Update(GameSession entity)
        {
            throw new NotImplementedException();
        }
    }
}
