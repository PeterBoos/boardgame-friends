using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BGF.App.Core.Entities;
using BGF.App.Data;
using BGF.App.Models;
using BGF.App.Models.User;
using BGF.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGF.App.Controllers
{
    public class UserController : Controller
    {
        private readonly IDbServiceBase<Boardgame> _boardGameDbService;
        private readonly ApplicationDbContext _context;

        public UserController(IDbServiceBase<Boardgame> boardGameDbService,
            ApplicationDbContext context)
        {
            _boardGameDbService = boardGameDbService;
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> BoardGames()
        {
            var boardgameService = new BoardGameDbService(_context);
            var myBoardgames = await boardgameService.GetUsersBoardgames(User.Identity.Name);
            
            return View();
        }

        public IActionResult Sleeves()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public IActionResult Friends()
        {
            return View();
        }

        public IActionResult Company()
        {

            var vm = new CompanyViewModel();

            return View(vm);
        }
    }
}
