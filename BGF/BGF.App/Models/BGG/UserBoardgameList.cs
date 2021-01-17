using System.Collections.Generic;
using System.Xml.Serialization;

namespace BGF.App.Models.BGG
{
    [XmlRoot("items")]
    public class UserBoardgameList
    {
        public UserBoardgameList()
        {
            Items = new List<UserBoardgameListItem>();
        }

        [XmlElement(ElementName = "item")]
        public List<UserBoardgameListItem> Items { get; set; }
    }

    public class UserBoardgameListItem
    {        
        [XmlAttribute("objectid")]
        public string ObjectId { get; set; }

        [XmlAttribute("subtype")]
        public string SubType { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "yearpublished")]
        public int YearPublished { get; set; }

        [XmlElement(ElementName = "image")]
        public string Image { get; set; }

        [XmlElement(ElementName = "thumbnail")]
        public string Thumbnail { get; set; }

        [XmlElement(ElementName = "numplays")]
        public int NumPlays { get; set; }
    }
}
