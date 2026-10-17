using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfySelf.Patients.Application.Models.DTOs
{
    public class PatientDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
    }
}
