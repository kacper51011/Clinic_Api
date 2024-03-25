using Clinic_Api.Application.Dto;
using Clinic_Api.Application.Exceptions;
using Clinic_Api.Domain.Interfaces;
using MediatR;

namespace Clinic_Api.Application.Queries.GetPatientById
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, GetPatientResponseDto>
    {
        private readonly IPatientsRepository _patientsRepository;

        public GetPatientByIdQueryHandler(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<GetPatientResponseDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var patient = await _patientsRepository.GetPatientById(request.Id);

                if (patient == null)
                {
                    throw new NotFoundException("Couldn`t find Patient with specified Id");
                }

                var dto = new GetPatientResponseDto()
                {
                  PatientId = patient.PatientId,
                  FirstName = patient.FirstName,
                  LastName = patient.LastName,
                  Street = patient.Street,
                  PostalCode = patient.PostalCode,
                  Pesel = patient.Pesel,
                  City = patient.City,
                };

                return dto;
            }
            catch (NotFoundException ex)
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
