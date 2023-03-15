using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_estate_Nyckelpigan.Models
{
    internal class Case
    {
        public int Id { get; set; }

        public string InternalCaseId { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string IncomingDate { get; set; } = string.Empty;
        public string PropertyManagerComment { get; set; } = string.Empty;
    }
}
