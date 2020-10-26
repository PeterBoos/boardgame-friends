using System;

namespace BgFriends.App.Data.Models
{
    public class Boardgame
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string BggId { get; set; }
        public string Description { get; set; }
    }
}
