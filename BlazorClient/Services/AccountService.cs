using System.Net.Http.Headers;
using System.Net.Http.Json;
using BlazorClient.Helpers;
using BlazorClient.Models;

namespace BlazorClient.Services
{
    public class AccountService
    {
        private readonly HttpClient _http;

        public AccountService(HttpClient http)
        {
            _http = http;
        }

        private async Task SetAuthorizationHeader()
        {
            var token = await TokenStorageHelper.GetToken();
            if(! string.IsNullOrEmpty(token))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
        
        public async Task<List<Account>> GetAccountsAsync()
        {
            await SetAuthorizationHeader();
            return await _http.GetFromJsonAsync<List<Account>>("api/accounts");
        }

        public async Task CreateAccountAsync(Account account)
        {
            await SetAuthorizationHeader();
            await _http.PostAsJsonAsync("api/accounts", account);
        }

        public async Task DeleteAccountAsync(int id)
        {
            await SetAuthorizationHeader();
            await _http.DeleteAsync($"api/accounts/{id}");
        }
    }
}
