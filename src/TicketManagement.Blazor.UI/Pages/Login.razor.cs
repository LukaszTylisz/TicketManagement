using Microsoft.AspNetCore.Components;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models;

namespace TicketManagement.Blazor.UI.Pages
{
    public partial class Login
    {
        public LoginVM Model { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Login()
        {
        }

        protected override void OnInitialized()
        {
            Model = new LoginVM();
        }

        protected async Task HandleLogin()
        {
            if (await AuthenticationService.AuthenticateAsync(Model.Email, Model.Password))
            {
                NavigationManager.NavigateTo("/");
            }
            Message = "Username/password combination unknown";
        }
    }
}