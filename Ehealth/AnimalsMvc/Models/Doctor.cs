// Models/Patient.cs
namespace AnimalsMvc.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Email { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
        public string? Specialite { get; set; }
    }
}