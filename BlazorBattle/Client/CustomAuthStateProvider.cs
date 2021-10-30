using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorBattle.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public CustomAuthStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal());

            if (await _localStorageService.GetItemAsync<bool>("isAuthenticated"))
            {
                var idenitity = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, "Hero")
            }, "test authentication type");

                var user = new ClaimsPrincipal(idenitity);
                state = new AuthenticationState(user);
            }
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
    }
}
