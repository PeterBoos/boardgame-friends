using System.Collections.Generic;

namespace BGF.App.Models.BGG
{
    public class BoardgameDetails
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Thumbnail { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int YearPublished { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlayTime { get; set; }
        public int MaxPlayTime { get; set; }
        public int MinAge { get; set; }

        public List<BoardgamePropertyLink> Properties { get; set; }
    }

    public class BoardgamePropertyLink
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
