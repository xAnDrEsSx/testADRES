using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestADRES.Domain.Entities.Common;

namespace TestADRES.Domain.Entities
{
    [Table("suppliers")]
    public class Supplier : BaseDomainModel
    {
        [Key]
        [Comment("Unique ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Column("legal_name", TypeName = "varchar(255)")]
        [Comment("Legal name of the supplier")]
        public string LegalName { get; set; } = string.Empty;

        [Column("document_number", TypeName = "varchar(50)")]
        [Comment("Document number of the supplier, e.g., tax ID")]
        public string DocumentNumber { get; set; } = string.Empty;

        [Column("phone", TypeName = "varchar(30)")]
        [Comment("Phone number of the supplier")]
        public string Phone { get; set; } = string.Empty;

        [Column("email", TypeName = "varchar(100)")]
        [Comment("Email address of the supplier")]
        public string Email { get; set; } = string.Empty;

        [Column("is_active")]
        [Comment("Indicates whether the supplier is active")]
        public bool IsActive { get; set; } = true;

        [Comment("List of requirements associated with the supplier")]
        public virtual ICollection<Requirement> Requirements { get; set; } = [];
    }
}
