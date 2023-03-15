namespace Real_estate_Nyckelpigan.Models
{
    internal class CreateCase
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string InternalCaseId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string IncomingDate { get; set; } = string.Empty;
        public string PropertyManagerComment { get; set; } = string.Empty;
    }
}
