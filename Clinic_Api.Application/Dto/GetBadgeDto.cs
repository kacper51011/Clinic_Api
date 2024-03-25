using Clinic_Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Dto
{
    public class GetBadgeResponseDto
    {
        public string Id { get; set; }
        public string BadgePrintCommand {  get; set; }

        public byte[] Badge { get; set; }

    }

    internal static class PatientToBadgeExtension
    {
        internal static GetBadgeResponseDto GetBadgeResponseDto(this Patient patient)
        {
            //todo
        }
    }
}
