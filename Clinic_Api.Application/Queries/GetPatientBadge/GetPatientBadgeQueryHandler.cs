using Clinic_Api.Application.Dto;
using Clinic_Api.Application.Exceptions;
using Clinic_Api.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Queries.GetPatientBadge
{
    public class GetPatientBadgeQueryHandler : IRequestHandler<GetPatientBadgeQuery, GetPatientBadgeResponseDto>
    {
        private readonly IPatientsRepository _patientsRepository;

        public GetPatientBadgeQueryHandler(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<GetPatientBadgeResponseDto> Handle(GetPatientBadgeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var patient = await _patientsRepository.GetPatientById(request.Id);
                if (patient == null)
                {
                    throw new NotFoundException("Can`t find patient with specified Id");
                }

                var dto = patient.GetBadgeResponseDto();

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
