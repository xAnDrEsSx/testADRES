using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestADRES.Domain.Entities
{
    [Table("historical_requirements")]
    public class HistoricalRequirement
    {
        [Key]
        [Comment("Unique ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [ForeignKey("Requirement")]
        [Column("requirement_id")]
        public Guid RequirementId { get; set; }

        [Column("field_name", TypeName = "varchar(100)")]
        public string FieldName { get; set; } = string.Empty;

        [Column("old_value", TypeName = "varchar(200)")]
        public string OldValue { get; set; } = string.Empty;

        [Column("new_value", TypeName = "varchar(200)")]
        public string NewValue { get; set; } = string.Empty;

        [ForeignKey("User")]
        [Column("changed_by")]
        public Guid ChangedBy { get; set; }

        [Column("change_date")]
        public DateTime ChangeDate { get; set; }

        public virtual Requirement Requirement { get; set; } = new Requirement();
        public virtual User User { get; set; } = new User();
    }
}
