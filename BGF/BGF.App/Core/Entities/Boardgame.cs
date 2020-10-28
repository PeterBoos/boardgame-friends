using System;

namespace BGF.App.Core.Entities
{
    public class Boardgame
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string BggId { get; set; }
        public string Description { get; set; }
    }
}
