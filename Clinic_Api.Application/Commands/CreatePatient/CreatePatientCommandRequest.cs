using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Commands.CreatePatient
{
    public class CreatePatientCommandRequest : IRequestHandler<CreatePatientCommandRequest, string>
    {
        public Task<string> Handle(CreatePatientCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
