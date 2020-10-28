using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BGF.App.Core.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public DateTime RegisterDate { get; set; }

        public List<Boardgame> BoardGames { get; set; }
        public List<GameSession> GameSessions { get; set; }
    }
}
