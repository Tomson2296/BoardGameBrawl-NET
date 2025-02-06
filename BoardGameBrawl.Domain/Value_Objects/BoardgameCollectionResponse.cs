#nullable disable
using System.Xml.Serialization;

namespace BoardGameBrawl.Domain.Value_objects
{
    [XmlRoot(ElementName = "items")]
    public class BoardgameCollectionResponse
    {
        [XmlAttribute("totalitems")]
        public int TotalItems { get; set; }

        [XmlIgnore]
        [XmlAttribute("termsofuse")]
        public string TermsOfUse { get; set; }

        [XmlIgnore]
        [XmlAttribute("pubdate")]
        public string PublicationDate { get; set; }

        [XmlElement(ElementName = "item")]
        public List<CollectionItem> Items { get; set; }
    }

    public class CollectionItem
    {
        [XmlIgnore]
        [XmlAttribute("objecttype")]
        public string ObjectType { get; set; }

        [XmlAttribute("objectid")]
        public int ObjectId { get; set; }

        [XmlIgnore]
        [XmlAttribute("subtype")]
        public string SubType { get; set; }

        [XmlIgnore]
        [XmlAttribute("collid")]
        public int CollectionId { get; set; }

        [XmlElement("name")]
        public BoardgameName Name { get; set; }

        [XmlElement("yearpublished")]
        public int YearPublished { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("thumbnail")]
        public string Thumbnail { get; set; }

        [XmlIgnore]
        [XmlElement("status")]
        public Status Status { get; set; }

        [XmlElement("numplays")]
        public int NumPlays { get; set; }
    }

    public class BoardgameName
    {
        [XmlIgnore]
        [XmlAttribute("sortindex")]
        public int SortIndex { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class Status
    {
        [XmlAttribute("own")]
        public int Own { get; set; }

        [XmlAttribute("prevowned")]
        public int PreviouslyOwned { get; set; }

        [XmlAttribute("fortrade")]
        public int ForTrade { get; set; }

        [XmlAttribute("want")]
        public int Want { get; set; }

        [XmlAttribute("wanttoplay")]
        public int WantToPlay { get; set; }

        [XmlAttribute("wanttobuy")]
        public int WantToBuy { get; set; }

        [XmlAttribute("wishlist")]
        public int Wishlist { get; set; }

        [XmlAttribute("preordered")]
        public int Preordered { get; set; }

        [XmlAttribute("lastmodified")]
        public string LastModified { get; set; }
    }
}