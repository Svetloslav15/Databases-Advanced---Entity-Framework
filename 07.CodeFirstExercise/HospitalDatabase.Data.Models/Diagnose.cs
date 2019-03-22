namespace HospitalDatabase.Data.Models
{
    using System;

    public class Diagnose
    {
        public int DiagnoseId { get; set; }

        public int PatientId { get; set; }

        public string Name { get; set; }

        public string Comments { get; set; }

        public Patient Patient { get; set; }
    }
}
