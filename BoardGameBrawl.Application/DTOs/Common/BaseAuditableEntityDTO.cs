namespace BoardGameBrawl.Application.DTOs.Common
{
    public class BaseAuditableEntityDTO : BaseEntityDTO
    {
        public DateTime CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
