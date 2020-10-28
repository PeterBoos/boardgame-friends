using System;

namespace BGF.App.Core.Entities
{
    public class GameSessionDate
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string Place { get; set; }

        public GameSession GameSession { get; set; }
    }
}
