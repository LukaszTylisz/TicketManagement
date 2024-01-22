using System.ComponentModel.DataAnnotations;
using TicketManagement.Blazor.UI.Models.TicketTypes;

namespace TicketManagement.Blazor.UI.Models.TicketRequests
{
    public class TicketRequestVm
    {
        public int Id { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Date Actioned")]
        public DateTime DateActioned { get; set; }

        [Display(Name = "Approval State")]
        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }
        public TicketTypeVm TicketType { get; set; } = new TicketTypeVm();
        public ClientVm Client { get; set; } = new ClientVm();

        [Display(Name = "Start Date")]
        [Required]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Ticket Type")]
        [Required]
        public int TicketTypeId { get; set; }

        [Display(Name = "Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }

    }
}
