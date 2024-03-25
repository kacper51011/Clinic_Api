using Clinic_Api.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Queries.GetPatientBadge
{
    public record GetPatientBadgeQuery(string Id): IRequest<GetPatientBadgeResponseDto>
    {
    }
}
