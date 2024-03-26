using Clinic_Api.Application.Paging;
using Clinic_Api.Domain;
using Clinic_Api.Domain.Entities;
using Clinic_Api.Domain.Interfaces;
using Clinic_Api.Infrastructure.DbSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SharpCompress.Common;

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

            _patientsCollection.Indexes.CreateOne(new CreateIndexModel<Patient>(Builders<Patient>.IndexKeys.Text(x => x.FullName)));
        }

        public async Task DeletePatient(string patientId)
        {
            await _patientsCollection.FindOneAndDeleteAsync(x => x.PatientId == patientId);
        }
        public async Task<List<Patient>> GetPatientsByNames(string textQuery)
        {
            var query = Builders<Patient>.Filter.Text(textQuery);
            var data = await _patientsCollection.Find(query).ToListAsync();

            return data;
        }

        public async Task<List<Patient>> GetPaginatedPatients(int page, int pageSize)
        {
            var patients = await _patientsCollection
                .Find(_ => true)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return patients;
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
            await _patientsCollection.ReplaceOneAsync(e => e.PatientId == patient.PatientId, patient, new ReplaceOptions()
            {
                IsUpsert = true
            });
        }
    }
}
