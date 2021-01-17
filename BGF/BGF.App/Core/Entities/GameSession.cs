using System;
using System.Collections.Generic;

namespace BGF.App.Core.Entities
{
    public class GameSession
    {
        public Guid Id { get; set; }

        //public List<User> Users { get; set; }
        public List<GameSessionDate> SuggestedDates { get; set; }
        public List<GameSessionBoardgame> SuggestedBoardgames { get; set; }
        public List<UserGameSession> Users { get; set; }
        public int MinUsers { get; set; }
        public int MaxUsers { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        //public List<SessionComment> Comments { get; set; }
    }
}
