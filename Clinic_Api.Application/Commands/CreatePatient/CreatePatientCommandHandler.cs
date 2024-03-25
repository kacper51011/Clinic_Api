using Clinic_Api.Application.Exceptions;
using Clinic_Api.Domain.Entities;
using Clinic_Api.Domain.Interfaces;
using MediatR;

namespace Clinic_Api.Application.Commands.CreatePatient
{
    public class CreatePatientCommandRequestHandler : IRequestHandler<CreatePatientCommandRequest, string>
    {
        private readonly IPatientsRepository _patientsRepository;

        public CreatePatientCommandRequestHandler(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<string> Handle(CreatePatientCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // I did it only for simplicity
                var x = request.dto;

                var PatientWithSamePesel = await _patientsRepository.GetPatientByPesel(x.Pesel);
                if (PatientWithSamePesel != null)
                {
                    throw new AlreadyExistsException("Patient already exists in database");
                }

                var patientToCreate = Patient.Create(x.FirstName, x.LastName, x.Pesel, x.Street, x.City, x.PostalCode);

                await _patientsRepository.CreateOrUpdatePatient(patientToCreate);

                return patientToCreate.PatientId;

            }
            catch (AlreadyExistsException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
