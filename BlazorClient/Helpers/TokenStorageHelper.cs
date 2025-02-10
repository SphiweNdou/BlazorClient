using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorClient.Helpers
{
    public static class TokenStorageHelper
    {
        private static IJSRuntime _jsRuntime;

        public static void  Initialise(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }

        public static async Task SetToken(string token)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", token);
        }

        public static async Task<string> GetToken()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        }

        public static async Task RemoveToken()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
        }
    }
}
