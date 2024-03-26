using Clinic_Api.Application.Dto;
using Clinic_Api.Application.Paging;
using Clinic_Api.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Queries.GetPatients
{
    public record GetPatientsQuery(PaginationParameters pagination): IRequest<List<GetPatientResponseDto>>
    {
    }
}
