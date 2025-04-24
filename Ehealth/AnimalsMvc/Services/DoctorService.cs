// Services/PatientService.cs
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AnimalsMvc.Models;

namespace AnimalsMvc.Services
{
    public class DoctorService
    {
        private readonly HttpClient _httpClient;

        public DoctorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            var response = await _httpClient.GetAsync("http://backend-service:8080/api/medecins");
            response.EnsureSuccessStatusCode(); // L�ve une exception si la r�ponse n'est pas r�ussie
            return await response.Content.ReadFromJsonAsync<IEnumerable<Doctor>>();
        }
    }
}