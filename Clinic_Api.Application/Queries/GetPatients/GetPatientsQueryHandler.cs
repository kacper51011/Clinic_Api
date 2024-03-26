using Clinic_Api.Application.Dto;
using Clinic_Api.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Queries.GetPatients
{
    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, List<GetPatientResponseDto>>
    {
		private readonly IPatientsRepository _patientsRepository;

        public GetPatientsQueryHandler(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<List<GetPatientResponseDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
			try
			{
                var paginatedPatients = await _patientsRepository.GetPaginatedPatients(request.pagination.Page, request.pagination.PageSize);

                List<GetPatientResponseDto> data = new List<GetPatientResponseDto>();
                foreach (var patient in paginatedPatients)
                {
                    var dto = new GetPatientResponseDto()
                    {
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        City = patient.City,
                        PatientId = patient.PatientId,
                        PostalCode = patient.PostalCode,
                        Pesel = patient.Pesel,
                        Street = patient.Street
                    };
                    data.Add(dto);
 
                }
                   return data;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
