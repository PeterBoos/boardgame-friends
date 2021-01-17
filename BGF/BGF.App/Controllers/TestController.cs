using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BGF.App.Data;
using BGF.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGF.App.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly BoardGameDbService _boardgameDbService;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
            //_boardgameDbService = boardGameDbService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UpdateUserCollection()
        {
            var username = WebUtility.UrlEncode("Peter Boos");
            var bggService = new BggService(_context);

            await bggService.UpdateUsersBggGamesList(username, User.Identity.Name);

            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> GetUserBoardgames(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                username = User.Identity.Name;
            }

            var boardgameDbService = new BoardGameDbService(_context);
            var boardgames = await boardgameDbService.GetUsersBoardgames(username);

            return View(boardgames);
        }
    }
}
