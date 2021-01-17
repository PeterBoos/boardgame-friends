using System;

namespace BGF.App.Core.Entities
{
    public class UserBoardgame
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid BoardgameId { get; set; }
        public Boardgame Boardgame { get; set; }
    }
}
