using Clinic_Api.Application.Dto;
using Clinic_Api.Application.Exceptions;
using Clinic_Api.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Commands.EditPatientPersonalData
{
    public class EditPatientPersonalDataCommandHandler : IRequestHandler<EditPatientPersonalDataCommandRequest, string>
    {
		private readonly IPatientsRepository _patientsRepository;

        public EditPatientPersonalDataCommandHandler(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<string> Handle(EditPatientPersonalDataCommandRequest request, CancellationToken cancellationToken)
        {
			try
			{
                // just for simplicity
                var x = request.dto;
                var patient = await _patientsRepository.GetPatientById(request.id);
                if (patient == null)
                {
                    throw new NotFoundException("Couldn`t find patient with specified Id");
                }

                // I decided that People these times can change names, gender etc. So Pesel is also included in edition
                patient.UpdatePersonalData(x.FirstName, x.LastName, x.Pesel, x.Street, x.City, x.PostalCode);
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
