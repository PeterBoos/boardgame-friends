using System.Collections.Generic;
using System.Xml.Serialization;

namespace BGF.App.Models.BGG
{
    [XmlRoot("items")]
    public class UserBoardgameList
    {
        public List<UserBoardgameListItem> Items { get; set; }
    }

    public class UserBoardgameListItem
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int YearPublished { get; set; }
        public string Image { get; set; }
        public string Thumbnail { get; set; }

    }
}
