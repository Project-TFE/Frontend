﻿// Models/Patient.cs
namespace AnimalsMvc.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Email { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
    }
}