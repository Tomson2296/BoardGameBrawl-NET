namespace BoardGameBrawl.Application.DTOs.Common
{
    public class BaseAuditableEntityDTO : BaseEntityDTO
    {
        public DateTimeOffset CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTimeOffset LastModifiedDate { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
