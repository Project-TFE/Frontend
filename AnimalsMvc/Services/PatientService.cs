// Services/PatientService.cs
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AnimalsMvc.Models;

namespace AnimalsMvc.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            var response = await _httpClient.GetAsync("http://backend-service:8080/api/patients");
            response.EnsureSuccessStatusCode(); // Lève une exception si la réponse n'est pas réussie
            return await response.Content.ReadFromJsonAsync<IEnumerable<Patient>>();
        }
    }
}
