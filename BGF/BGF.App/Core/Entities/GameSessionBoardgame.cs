using System;

namespace BGF.App.Core.Entities
{
    public class GameSessionBoardgame
    {
        public Guid GameSessionId { get; set; }
        public GameSession GameSession { get; set; }
        public Guid BoardgameId { get; set; }
        public Boardgame Boardgame { get; set; }
    }
}
