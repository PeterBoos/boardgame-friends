﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BGF.App.Core.Entities;
using BGF.App.Models;
using BGF.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGF.App.Controllers
{
    public class UserController : Controller
    {
        private readonly IDbServiceBase<Boardgame> _boardGameDbService;
        public UserController(IDbServiceBase<Boardgame> boardGameDbService)
        {
            _boardGameDbService = boardGameDbService;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> BoardGames()
        {
            var vm = new BoardGamesViewModel();
            // TODO: Get board games from BGG API
            vm.BggBoardGames = new List<Boardgame>() 
            { 
                new Boardgame() {Name = "Monopoly", Id = Guid.Parse("2f73b0af-921f-43fe-be43-626d1047eda4") },
                new Boardgame() {Name = "Settlers of catan", Id = Guid.Parse("985c492d-5366-4eae-bc2c-2242195c04e4")}
            };

            var list = await _boardGameDbService.GetAll();
            vm.MyBoardGames = list.ToList();
            
            return View(vm);
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
    }
}
