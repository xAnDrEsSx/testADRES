using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestADRES.Domain.Entities.Common;

namespace TestADRES.Domain.Entities
{
    [Table("requirement_statuses")]
    public class RequirementStatus : BaseDomainModel
    {
        [Key]
        [Column("id")]
        [Comment("Unique ID for the requirement status")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(50)")]
        [Comment("The name of the requirement status, e.g., 'Pending', 'Approved'")]
        public string Name { get; set; } = string.Empty;

        [Comment("List of requirements associated with this status")]
        public virtual ICollection<Requirement> Requirements { get; set; } = [];
    }
}

