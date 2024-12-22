using BoardGameBrawl.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities
{
    public class BoardgameCategory : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Category { get; set; }

        //public bool IsSoftDeleted { get; set; } = false;

        //public DateTime DeletedDate { get; set; }

        public ICollection<BoardgameCategoryTag>? BoardgameCategoryTags { get; set; }
    }
}
