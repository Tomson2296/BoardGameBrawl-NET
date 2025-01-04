namespace BoardGameBrawl.Domain.Common
{
    public interface ISoftDeleted
    {
        public bool IsSoftDeleted { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}
