using Course_Project.Data.Models;
using CourseProject.Mvc2.Interfaces;
using CourseProject.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CourseProject.Mvc2.Service
{
    /// <inheritdoc cref="IIdentityService"/>
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;

        public IdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<(string token, IList<string> roles)> LoginAsync(object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/user/login");
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var record = await response.Content.ReadFromJsonAsync<UserAuthModel>();
            return (record.Token, record.Roles);
        }

        public async Task<(string Email, string Password, string PasswordConfirm)> RegisterAsync(object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/user/registration");
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var record = await response.Content.ReadFromJsonAsync<UserRegModel>();
            
            return (record.Email, record.Password, record.PasswordConfirm);
        }
    }
}
