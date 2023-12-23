using System.ComponentModel.DataAnnotations;
using TicketManagement.Blazor.UI.Models.TicketTypes;

namespace TicketManagement.Blazor.UI.Models.TicketAllocations
{
    public class UpdateTicketAllocationVm
    {
        public int Id { get; set; }

        [Display(Name = "Number Of Days")]
        [Range(1, 50, ErrorMessage = "Enter Valid Number")]
        public int NumberOfDays { get; set; }
        public TicketTypeVM TicketType { get; set; }

    }
}
