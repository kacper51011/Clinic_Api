using Clinic_Api.Application.Dto;
using Clinic_Api.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Queries.GetPatientByText
{
    public class GetPatientsByTextQueryHandler : IRequestHandler<GetPatientsByTextQuery, List<GetPatientResponseDto>>
    {
		private readonly IPatientsRepository _patientsRepository;

        public GetPatientsByTextQueryHandler(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<List<GetPatientResponseDto>> Handle(GetPatientsByTextQuery request, CancellationToken cancellationToken)
        {
			try
			{
                var patients = await _patientsRepository.GetPatientsByNames(request.textQuery);

                List<GetPatientResponseDto> listToReturn = new List<GetPatientResponseDto>();

                foreach (var patient in patients)
                {
                    var dto = new GetPatientResponseDto()
                    {
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        City = patient.City,
                        PatientId = patient.PatientId,
                        PostalCode = patient.PostalCode,
                        Pesel = patient.Pesel,
                        Street = patient.Street,

                    };
                    listToReturn.Add(dto);
                }
                return listToReturn;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
