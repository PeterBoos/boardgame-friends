using System;
using System.Collections.Generic;

namespace BgFriends.App.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime RegisterDate { get; set; }

        public List<Boardgame> BoardGames { get; set; }
        public List<GameSession> GameSessions { get; set; }
    }
}
