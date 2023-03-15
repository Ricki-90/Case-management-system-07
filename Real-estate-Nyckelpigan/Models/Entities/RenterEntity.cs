using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Real_estate_Nyckelpigan.Models.Entities
{
    internal class RenterEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; }

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!;
        public int CaseId { get; set; }
        public CaseEntity Case { get; set; } = null!;
    }
}
