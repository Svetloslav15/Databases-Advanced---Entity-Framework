namespace HospitalDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PatientMedicament
    {
        [Key]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int MedicamentId { get; set; }
        public Medicament Medicament { get; set; }
    }
}
