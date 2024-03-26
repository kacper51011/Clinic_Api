using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Dto
{
    public class CreatePatientRequestDto
    {
        [MaxLength(15)]
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [MaxLength(15)]
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Pesel must have exactly thirteen characters.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "PESEL can include only numbers.")]
        public string Pesel { get; set; }
        [MaxLength(15)]
        [Required]
        [DataType(DataType.Text)]
        public string Street { get; set; }
        [DataType(DataType.Text)]
        [MaxLength(15)]
        [Required]
        public string City { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
    }
}
