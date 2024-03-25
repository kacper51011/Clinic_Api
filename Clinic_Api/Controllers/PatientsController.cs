using Clinic_Api.Application.Dto;
using Clinic_Api.Application.Paging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        // A small comment here, I decided to mix proper (at least in my opinion)
        // naming of endpoints used in classical Rest and CQRS kinds of Api`s

        [HttpGet]
        public async Task<ActionResult<List<GetPatientResponseDto>>> GetPatients([FromQuery] PaginationParameters paginationParameters)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetPatientResponseDto>> GetPatientById([FromRoute]string Id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreatePatient(string Id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeletePatient([FromRoute]string Id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<string>> EditPatientPersonalData([FromRoute] string Id, [FromBody]  EditPatientPersonalDataRequestDto editPatientDataRequestDto)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
