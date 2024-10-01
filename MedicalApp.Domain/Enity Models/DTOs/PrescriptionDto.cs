using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Enity_Models.DTOs
{
    public class PrescriptionDto
    {
        public string Medication { get; set; }
        public string Dosage { get; set; }
    }
}
