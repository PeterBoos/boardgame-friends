using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGF.App.Data;
using BGF.App.Models.Boardgames;
using BGF.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace BGF.App.Controllers
{
    public class BoardgamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoardgamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var boardgameService = new BoardGameDbService(_context);
            var boardgames = await boardgameService.GetAll();
            var boardgamesVM = new BoardgamesListVM { Boardgames = new List<BoardgameVM>() };

            foreach (var boardgame in boardgames)
            {
                var boardgameVM = new BoardgameVM
                {
                    Name = boardgame.Name,
                    Description = boardgame.Description,
                    ThumbNail = boardgame.ThumbNail,
                    YearPublished = boardgame.YearPublished
                };
                boardgamesVM.Boardgames.Add(boardgameVM);
            }

            return View(boardgamesVM);
        }

        public async Task<IActionResult> Details(string id)
        {
            var boardgameService = new BoardGameDbService(_context);
            var boardgame = _context.BoardGames.SingleOrDefault(e => e.Id.ToString() == id);

            if (boardgame == null)
            {
                return NotFound();
            }

            return View();
        }
    }
}
