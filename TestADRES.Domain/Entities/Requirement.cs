using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestADRES.Domain.Entities.Common;

namespace TestADRES.Domain.Entities
{
    [Table("requirements")]
    public class Requirement : BaseDomainModel
    {
        [Key]
        [Column("id", TypeName = "uniqueidentifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Unique identifier for the requirement")]
        public Guid Id { get; set; }

        [ForeignKey("Supplier")]
        [Column("supplier_id")]
        [Comment("The ID of the supplier for this requirement")]
        public Guid SupplierId { get; set; }

        [Column("item_type", TypeName = "text")]
        [Comment("The ID of the item type associated with the requirement")]
        public string ItemType { get; set; } = string.Empty;

        [Column("budget", TypeName = "decimal(18,2)")]
        [Comment("The budget allocated for the requirement")]
        public decimal Budget { get; set; } = 0;

        [ForeignKey("BusinessUnit")]
        [Column("business_unit_id")]
        [Comment("The ID of the business unit associated with the requirement")]
        public int BusinessUnitId { get; set; }

        [Column("quantity", TypeName = "decimal(18,2)")]
        [Comment("The quantity of the items required")]
        public decimal Quantity { get; set; } = 0;

        [Column("unit_value", TypeName = "decimal(18,2)")]
        [Comment("The unit value (cost per unit) of the item")]
        public decimal UnitValue { get; set; } = 0;

        [Column("acquisition_date")]
        [Comment("The date when the requirement is acquired")]
        public DateTime AcquisitionDate { get; set; }

        [Column("documentation", TypeName = "varchar(255)")]
        [Comment("The documentation associated with the requirement (e.g., purchase order, invoice)")]
        public string Documentation { get; set; } = string.Empty;

        [ForeignKey("RequirementStatus")]
        [Column("requirement_status_id")]
        [Comment("The status ID of the requirement (e.g., pending, approved, rejected)")]
        public int RequirementStatusId { get; set; }

        [ForeignKey("User")]
        [Column("created_by_user_id")]
        [Comment("The ID of the user who created this requirement")]
        public Guid CreatedByUserId { get; set; }

        [Comment("Navigation property to the supplier related to this requirement")]
        public virtual Supplier? Supplier { get; set; }

        [Comment("Navigation property to the status of the requirement")]
        public virtual RequirementStatus? RequirementStatus { get; set; }

        [Comment("Navigation property to the user who created this requirement")]
        public virtual User? User { get; set; }

        [Comment("Navigation property to the business unit associated with this requirement")]
        public virtual BusinessUnit? BusinessUnit { get; set; }
    }
}
