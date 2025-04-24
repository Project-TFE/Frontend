using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AnimalsMvc.Models;

namespace AnimalsMvc.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "http://backend-service:8080/api/medecins";

        public DoctorController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler);
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var doctors = JsonConvert.DeserializeObject<IEnumerable<Doctor>>(
                    await response.Content.ReadAsStringAsync());
                return View(doctors);
            }
            return StatusCode((int)response.StatusCode, "Erreur lors de la récupération des médecins.");
        }

        [Authorize(Roles = "medecin")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "medecin")]
        public async Task<IActionResult> Patients()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}/patients");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var patients = JsonConvert.DeserializeObject<IEnumerable<Patient>>(content);
                    return View(patients);
                }
                
                TempData["Error"] = "Impossible de récupérer la liste des patients";
                return View(new List<Patient>());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Une erreur est survenue lors de la connexion au serveur";
                return View(new List<Patient>());
            }
        }
    }
}
