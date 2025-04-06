using AnimalsMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsMvc.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsApiController : ControllerBase
    {
        private static List<Patient> _patients = new List<Patient>
        {
            new Patient { Id = 1, Nom = "Jean Dupont", Email = "jean.dupont@example.com", Adresse = "123 Rue de Paris", Telephone = "0123456789" },
            new Patient { Id = 2, Nom = "Marie Curie", Email = "marie.curie@example.com", Adresse = "456 Avenue Einstein", Telephone = "0987654321" }
        };

        // GET: api/PatientsApi
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_patients);
        }

        // GET: api/PatientsApi/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        // POST: api/PatientsApi
        [HttpPost]
        public IActionResult Create([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }

            patient.Id = _patients.Max(p => p.Id) + 1;
            _patients.Add(patient);

            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
        }

        // PUT: api/PatientsApi/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Patient patient)
        {
            var existingPatient = _patients.FirstOrDefault(p => p.Id == id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            existingPatient.Nom = patient.Nom;
            existingPatient.Email = patient.Email;
            existingPatient.Adresse = patient.Adresse;
            existingPatient.Telephone = patient.Telephone;

            return NoContent();
        }

        // DELETE: api/PatientsApi/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            _patients.Remove(patient);

            return NoContent();
        }
    }
}
