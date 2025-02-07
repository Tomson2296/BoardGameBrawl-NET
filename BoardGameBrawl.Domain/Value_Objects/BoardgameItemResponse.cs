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
        public BoardGameAttribute YearPublished { get; set; }

        [XmlElement("minplayers")]
        public BoardGameAttribute MinPlayers { get; set; }

        [XmlElement("maxplayers")]
        public BoardGameAttribute MaxPlayers { get; set; }

        [XmlIgnore]
        [XmlElement("poll")]
        public List<BoardGamePoll> Polls { get; set; }

        [XmlElement("playingtime")]
        public BoardGameAttribute PlayingTime { get; set; }

        [XmlElement("minplaytime")]
        public BoardGameAttribute MinPlayTime { get; set; }

        [XmlElement("maxplaytime")]
        public BoardGameAttribute MaxPlayTime { get; set; }

        [XmlElement("minage")]
        public BoardGameAttribute MinAge { get; set; }

        [XmlIgnore]
        [XmlElement("poll-summary")]
        public List<PollSummary> PollSummaries { get; set; }

        [XmlElement("link")]
        public List<BoardGameLink> Links { get; set; }

        [XmlElement("statistics")]
        public BoardGameStatistics Statistics { get; set; }
    }

    public class BoardGameName
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("sortindex")]
        public int SortIndex { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
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

    public class BoardGameStatistics
    {
        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlElement("ratings")]
        public BoardGameRatings Rating { get; set; }
    }

    public class BoardGameRatings
    {
        [XmlElement("usersrated")]
        public BoardGameAttribute UsersRated { get; set; }

        [XmlElement("average")]
        public BoardGameDecimalAttribute Average { get; set; }

        [XmlElement("bayesaverage")]
        public BoardGameDecimalAttribute BayesAverage { get; set; }

        [XmlArray("ranks")]
        [XmlArrayItem("rank")]
        public List<BoardGameRank> Ranks { get; set; }

        [XmlElement("stddev")]
        public BoardGameDecimalAttribute StandardDeviation { get; set; }

        [XmlElement("median")]
        public BoardGameAttribute Median { get; set; }

        [XmlElement("owned")]
        public BoardGameAttribute Owned { get; set; }

        [XmlElement("trading")]
        public BoardGameAttribute Trading { get; set; }

        [XmlElement("wanting")]
        public BoardGameAttribute Wanting { get; set; }

        [XmlElement("wishing")]
        public BoardGameAttribute Wishing { get; set; }

        [XmlElement("numcomments")]
        public BoardGameAttribute NumComments { get; set; }

        [XmlElement("numweights")]
        public BoardGameAttribute NumWeights { get; set; }

        [XmlElement("averageweight")]
        public BoardGameDecimalAttribute AverageWeight { get; set; }
    }

    public class BoardGameRank
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("friendlyname")]
        public string FriendlyName { get; set; }

        [XmlAttribute("value")]
        public int Value { get; set; }

        [XmlAttribute("bayesaverage")]
        public double BayesAverage { get; set; }
    }

    public class BoardGameAttribute
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }

    public class BoardGameDecimalAttribute
    {
        [XmlAttribute("value")]
        public double Value { get; set; }
    }

}