using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Dto
{
    public class CreatePatientRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public DateTimeOffset HospitalizedFrom { get; set; }
        public DateTimeOffset HospitalizedTo { get; set; }
    }
}
