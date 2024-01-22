using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Blazor.UI.Models.TicketTypes;

public class TicketTypeVm
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Default Number Of Days")]
    public int DefaultDays { get; set; }
}