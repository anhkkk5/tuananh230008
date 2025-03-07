using GoodsManagementMVC.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace GoodsManagementMVC.Services
{
    public class HangHoaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public HangHoaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["GoodsApiUrl"]; // Lấy URL từ appsettings.json
        }

        public async Task<List<HangHoa>> GetHangHoaAsync()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<HangHoa>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<HangHoa>();
        }
    }
}
