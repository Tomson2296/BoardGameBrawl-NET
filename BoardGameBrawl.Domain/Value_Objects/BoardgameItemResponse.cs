#nullable disable
using System.Xml.Serialization;

namespace BoardGameBrawl.Domain.Value_objects
{
    [XmlRoot(ElementName = "items")]
    public class BoardgameItemResponse
    {
        [XmlIgnore]
        [XmlAttribute("termsofuse")]
        public string TermsOfUse { get; set; }

        [XmlElement(ElementName = "item")]
        public BoardGameItem Item { get; set; }
    }

    public class BoardGameItem
    {
        [XmlIgnore]
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("thumbnail")]
        public string Thumbnail { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("name")]
        public List<BoardGameName> Names { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("yearpublished")]
        public YearPublished YearPublished { get; set; }

        [XmlElement("minplayers")]
        public MinPlayers MinPlayers { get; set; }

        [XmlElement("maxplayers")]
        public MaxPlayers MaxPlayers { get; set; }

        [XmlIgnore]
        [XmlElement("poll")]
        public List<BoardGamePoll> Polls { get; set; }

        [XmlElement("playingtime")]
        public PlayingTime PlayingTime { get; set; }

        [XmlElement("minplaytime")]
        public MinPlayTime MinPlayTime { get; set; }

        [XmlElement("maxplaytime")]
        public MaxPlayTime MaxPlayTime { get; set; }

        [XmlElement("minage")]
        public MinAge MinAge { get; set; }

        [XmlIgnore]
        [XmlElement("poll-summary")]
        public List<PollSummary> PollSummaries { get; set; }

        [XmlElement("link")]
        public List<BoardGameLink> Links { get; set; }
    }

    public class BoardGameName
    {
        [XmlIgnore]
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlIgnore]
        [XmlAttribute("sortindex")]
        public int SortIndex { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }

    public class YearPublished
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }

    public class MinPlayers
    {
        [XmlAttribute("value")]
        public byte Value { get; set; }
    }

    public class MaxPlayers
    {
        [XmlAttribute("value")]
        public byte Value { get; set; }
    }

    public class BoardGamePoll
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("totalvotes")]
        public int TotalVotes { get; set; }

        [XmlElement("results")]
        public List<PollResults> Results { get; set; }
    }

    public class PollResults
    {
        [XmlAttribute("numplayers")]
        public string NumPlayers { get; set; }

        [XmlElement("result")]
        public List<PollResult> Results { get; set; }
    }

    public class PollResult
    {
        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("numvotes")]
        public int NumVotes { get; set; }

        [XmlAttribute("level")]
        public int? Level { get; set; }
    }

    public class PlayingTime
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }

    public class MinPlayTime
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }

    public class MaxPlayTime
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }

    public class MinAge
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }

    public class PollSummary
    {
        [XmlElement("result")]
        public List<SummaryResult> Results { get; set; }
    }

    public class SummaryResult
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }

    public class BoardGameLink
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlIgnore]
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}