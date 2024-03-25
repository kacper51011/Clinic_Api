using Clinic_Api.Domain;
using Clinic_Api.Domain.Entities;
using Clinic_Api.Domain.Interfaces;
using Clinic_Api.Infrastructure.DbSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Clinic_Api.Infrastructure.Repositories
{
    public class PatientsRepository : IPatientsRepository
    {
        private IMongoCollection<Patient> _patientsCollection;

        public PatientsRepository(IOptions<MongoSettings> patientsDatabaseSettings)
        {
            var mongoClient = new MongoClient(patientsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(patientsDatabaseSettings.Value.DatabaseName);

            _patientsCollection = mongoDatabase.GetCollection<Patient>(patientsDatabaseSettings.Value.CollectionName);
        }

        public async Task DeletePatient(string patientId)
        {
            await _patientsCollection.FindOneAndDeleteAsync(x => x.PatientId == patientId);
        }

        public Task<List<Patient>> GetPaginatedPatients(PaginationParameters pagination)
        {
            throw new NotImplementedException();
        }

        public async Task<Patient> GetPatientById(string patientId)
        {
            var patient = await _patientsCollection.Find(x => x.PatientId == patientId).FirstOrDefaultAsync();

            return patient;
        }
        public async Task<Patient> GetPatientByPesel(string pesel)
        {
            var patient = await _patientsCollection.Find(x => x.Pesel == pesel).FirstOrDefaultAsync();

            return patient;
        }

        public async Task CreateOrUpdatePatient(Patient patient)
        {

        }
    }
}
