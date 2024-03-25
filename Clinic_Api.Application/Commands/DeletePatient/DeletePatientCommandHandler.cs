using Clinic_Api.Application.Exceptions;
using Clinic_Api.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommandRequest>
    {
        private readonly IPatientsRepository _patientsRepository;

        public DeletePatientCommandHandler(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task Handle(DeletePatientCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var patient = await _patientsRepository.GetPatientById(request.Id);
                if (patient == null)
                {
                    throw new NotFoundException("Can`t find patient with specified Id");
                }
                
                await _patientsRepository.DeletePatient(request.Id);

                return;
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
