using BGF.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Models
{
    public class BoardGamesViewModel
    {
        public List<Boardgame> BggBoardGames { get; set; }
        public List<Boardgame> MyBoardGames { get; set; }

    }
}
