using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestADRES.Domain.Entities.Common;

namespace TestADRES.Domain.Entities
{
    [Table("business_units")]
    public class BusinessUnit : BaseDomainModel
    {
        [Key]
        [Column("id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Unique identifier for the business unit")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(50)")]
        [Comment("Name of the business unit")]
        public string Name { get; set; } = string.Empty;

        [Column("is_active")]
        [Comment("Indicates if the business unit is active")]
        public bool IsActive { get; set; } = true;

        // Navigation property for the related requirements
        [Comment("Navigation property for the related requirements")]
        public virtual ICollection<Requirement> Requirements { get; set; } = [];
    }
}
