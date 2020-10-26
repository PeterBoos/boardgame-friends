using System;
using System.Collections.Generic;

namespace BgFriends.App.Data.Models
{
    public class GameSession
    {
        public Guid Id { get; set; }

        //public List<User> Users { get; set; }
        public List<DateTime> SuggestedDates { get; set; }
        public List<Boardgame> SuggestedBoardgames { get; set; }
        public int MinUsers { get; set; }
        public int MaxUsers { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        //public List<SessionComment> Comments { get; set; }
    }
}
