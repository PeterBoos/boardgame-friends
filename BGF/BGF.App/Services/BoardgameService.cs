using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using BGF.App.Core.Entities;
using BGF.App.Data;
using BGF.App.Interfaces;
using BGF.App.Models.Boardgames;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Services
{
    public class BoardgameService : IBoardgameService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BoardgameService(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(BoardgameDto model)
        {
            var boardgame = _mapper.Map<Boardgame>(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var boardgame = _context.BoardGames.SingleOrDefault(e => e.Id.ToString() == id);
            _context.BoardGames.Remove(boardgame);
        }

        public async Task Delete(Boardgame boardgame)
        {
            _context.BoardGames.Remove(boardgame);
        }

        public async Task<IEnumerable<Boardgame>> GetAll()
        {
            var boardgames = _context.BoardGames.ToList();

            return boardgames;
        }

        public async Task<Boardgame> GetOnId(string id)
        {
            var boardgame = await _context.BoardGames.SingleOrDefaultAsync(e => e.Id.ToString() == id);

            return boardgame;
        }

        public async Task<IEnumerable<Boardgame>> GetUsers(string username)
        {
            var user = await _context.Users
                .Include(e => e.BoardGames)
                .ThenInclude(e => e.Boardgame)
                .SingleOrDefaultAsync(e => e.UserName == username);

            return user.BoardGames.Select(x => x.Boardgame);
        }

        public async Task Update(BoardgameDto model)
        {
            await _context.BoardGames.Persist(_mapper).InsertOrUpdateAsync(model);
            await _context.SaveChangesAsync();
        }
    }
}
