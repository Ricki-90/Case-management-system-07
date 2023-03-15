using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Real_estate_Nyckelpigan.Models.Entities
{
    [Index(nameof(InternalCaseId), IsUnique = true)]
    internal class CaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string InternalCaseId { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string IncomingDate { get; set; } = string.Empty;

        public string PropertyManagerComment { get; set; } = string.Empty;
    }
}
