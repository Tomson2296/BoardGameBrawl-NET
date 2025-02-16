using System.ComponentModel.DataAnnotations;

namespace BoardGameBrawl.Domain.Common
{
    public abstract class BaseAuditableEntity
    {
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        
        [MaxLength(256)]
        public string? CreatedBy { get; set; }
        

        public DateTimeOffset LastModifiedDate { get; set; }
        
        [MaxLength(256)]
        public string? LastModifiedBy { get; set; }
    }
}
