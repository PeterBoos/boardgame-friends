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

        public List<UserBoardgame> BoardGames { get; set; }
        public List<UserGameSession> GameSessions { get; set; }
        //public List<UserFriend> Friends { get; set; }
    }
}
