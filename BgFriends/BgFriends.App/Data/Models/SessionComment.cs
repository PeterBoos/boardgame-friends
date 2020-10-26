﻿using System;

namespace BgFriends.App.Data.Models
{
    public class SessionComment
    {
        public Guid Id { get; set; }

        public Guid GameSessionId { get; set; }

        public string Text { get; set; }
        public DateTime Date { get; set; }

        public GameSession GameSession { get; set; }
        //public User User { get; set; }
    }
}
