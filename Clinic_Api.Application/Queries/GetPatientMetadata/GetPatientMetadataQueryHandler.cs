using Clinic_Api.Application.Dto;
using Clinic_Api.Application.Exceptions;
using Clinic_Api.Domain.Interfaces;
using MediatR;

namespace Clinic_Api.Application.Queries.GetPatientMetadata
{
    public class GetPatientMetadataQueryHandler : IRequestHandler<GetPatientMetadataQuery, GetPatientMetadataResponseDto>
    {
        private readonly IPatientsRepository _patientsRepository;

        public GetPatientMetadataQueryHandler(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<GetPatientMetadataResponseDto> Handle(GetPatientMetadataQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var patient = await _patientsRepository.GetPatientById(request.Id);
                if (patient == null)
                {
                    throw new NotFoundException("Couldn`t find patient with specified Id");
                }
                var data = new GetPatientMetadataResponseDto()
                {
                    PatientId = patient.PatientId,
                    CreatedAt = patient.CreatedAt,
                    UpdatedAt = patient.UpdatedAt,
                    Version = patient.Version,


                };

                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
