using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Blazor.UI.Models.TicketTypes;

public class TicketTypeVM
{
    public int Id { get; set; }
    
    [Required] public string Name { get; set; }
    
    [Required]
    [Display(Name = "Default Number of Days")]
    public int DefaultDays { get; set; }
}