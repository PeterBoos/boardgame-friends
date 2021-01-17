using System;

namespace BGF.App.Core.Entities
{
    public class UserGameSession
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid GameSessionid { get; set; }
        public GameSession GameSession { get; set; }
    }
}
