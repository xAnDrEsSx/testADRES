using System.ComponentModel.DataAnnotations.Schema;

namespace TestADRES.Domain.Entities.Common
{
    public class BaseDomainModel
    {
        [Column("created_date")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [Column("last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }
    }
}
