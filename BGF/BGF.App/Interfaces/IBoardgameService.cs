using BGF.App.Core.Entities;
using BGF.App.Models.Boardgames;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGF.App.Interfaces
{
    public interface IBoardgameService
    {
        Task<Boardgame> GetOnId(string id);
        Task Add(BoardgameDto model);
        Task Update(BoardgameDto model);
        Task DeleteById(string id);
        Task Delete(Boardgame boardgame);
        Task<IEnumerable<Boardgame>> GetAll();
        Task<IEnumerable<Boardgame>> GetUsers(string username);
    }
}
