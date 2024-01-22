using System.ComponentModel.DataAnnotations;
using TicketManagement.Blazor.UI.Models.TicketTypes;

namespace HR.LeaveManagement.BlazorUI.Models.LeaveAllocations
{
    public class UpdateTicketAllocationVm
    {
        public int Id { get; set; }

        [Display(Name = "Number Of Days")]
        [Range(1, 50, ErrorMessage = "Enter Valid Number")]
        public int NumberOfDays { get; set; }
        public TicketTypeVm TicketType { get; set; }
    }
}
