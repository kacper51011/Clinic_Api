using Clinic_Api.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Commands.CreatePatient
{
    public record CreatePatientCommandHandler(CreatePatientRequestDto dto): IRequest<string>
    {
    }
}
