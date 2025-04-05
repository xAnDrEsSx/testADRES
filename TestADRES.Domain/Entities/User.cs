using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestADRES.Domain.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;

        [Column("lastName", TypeName = "varchar(50)")]
        public string LastName { get; set; } = string.Empty;

        [Column("email", TypeName = "varchar(100)")]
        public string Email { get; set; } = string.Empty;

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Requirement> Requirements { get; set; } = [];
    }
}
