using Clinic_Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Domain.Interfaces
{
    public interface IPatientsRepository
    {
        public Task<List<Patient>> GetPaginatedPatients(int page, int pageSize);

        public Task<Patient> GetPatientById(string patientId);

        public Task<Patient> GetPatientByPesel(string pesel);

        public Task<List<Patient>> GetPatientsByNames(string textQuery);
        public Task DeletePatient(string patientId);

        public Task CreateOrUpdatePatient(Patient patient);


    }
}
