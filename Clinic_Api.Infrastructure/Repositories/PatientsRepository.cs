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

        public Task CreatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task DeletePatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> GetPaginatedPatients(PaginationParameters pagination)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetPatientById(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
