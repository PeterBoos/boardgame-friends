using System;
using System.Collections.Generic;

namespace BGF.App.Core.Entities
{
    public class Boardgame
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string BggId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ThumbNail { get; set; }
        public int YearPublished { get; set; }

        public List<UserBoardgame> Owners { get; set; }
        public List<GameSessionBoardgame> GameSessions { get; set; }
    }
}
