using Clinic_Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Dto
{
    // Created for fun, dynamic native command for printers of zebra type, it prints the badge for patient
    //you can check How it Looks At https://labelary.com/viewer.html
    // It also generates qr code which can lead us to some kind of endpoint (actually its only Id, I think its more appropiate to implement it on mobile)
    public class GetPatientBadgeResponseDto
    {
        public string Id { get; set; }
        public string BadgePrintCommand {  get; set; }

        

    }

    internal static class PatientToBadgeExtension
    {
        internal static GetPatientBadgeResponseDto GetBadgeResponseDto(this Patient patient)
        {
            var command = $"^XA\r\n\r\n^CF0,60\r\n^FO50,50^GB100,100,100^FS\r\n^FO75,75^FR^GB100,100,100^FS\r\n^FO93,93^GB40,40,40^FS\r\n^FO220,50^FDBest Clinic^FS\r\n^CF0,30\r\n\r\n^FO50,250^GB700,3,3^FS\r\n^FO50,360^ADN,60,15^FD{patient.FirstName + patient.LastName}^FS\r\n\r\n\r\n^CFA,15\r\n^FO50,500^GB700,3,3^FS\r\n\r\n^CFA,40\r\n^FO50,550^FD{patient.City}^FS\r\n^FO50,630^FD{patient.Street}^FS\r\n^FO50,710^FD{patient.PostalCode}^FS\r\n\r\n^FX Third section with bar code.\r\n^CFA,15\r\n^FO50,800^GB700,3,3^FS\r\n^BY5,2,600\r\n^FO300,300^BQN,20,40^FDMM,A{patient.PatientId}^FS\r\n\r\n\r\n\r\n^XZ";
            var id = patient.PatientId;

            return new GetPatientBadgeResponseDto { Id = id, BadgePrintCommand = command };
        }
    }
}
