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
        public Task<List<Patient>> GetPaginatedPatients(PaginationParameters pagination);

        public Task<Patient> GetPatientById(string id);

        public Task DeletePatient(Patient patient);

        public Task UpdatePatient(Patient patient);

        public Task CreatePatient(Patient patient);


    }
}
