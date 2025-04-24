 
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AnimalsMvc.Models;

public class PatientsController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl = "http://backend-service:8080/api/patients";

    public PatientsController(HttpClient httpClient)
    {
        _httpClient = httpClient;
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        _httpClient = new HttpClient(handler);
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var response = await _httpClient.GetAsync(_apiUrl);
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

    // GET: /Patients/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var response = await _httpClient.GetStringAsync($"{_apiUrl}/{id}");
        var patient = JsonConvert.DeserializeObject<Patient>(response);

        if (patient == null)
        {
            return NotFound();
        }

        return View(patient);
    }

    // GET: /Patients/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var response = await _httpClient.GetStringAsync($"{_apiUrl}/{id}");
        var patient = JsonConvert.DeserializeObject<Patient>(response);

        if (patient == null)
        {
            return NotFound();
        }

        return View(patient);
    }

    // POST: /Patients/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Patient patient)
    {
        if (id != patient.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(patient),
                System.Text.Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PutAsync($"{_apiUrl}/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Erreur lors de la mise à jour du patient.");
        }

        return View(patient);
    }
}
