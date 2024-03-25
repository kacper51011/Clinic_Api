using Clinic_Api.Application.Commands.CreatePatient;
using Clinic_Api.Application.Commands.DeletePatient;
using Clinic_Api.Application.Commands.EditPatientPersonalData;
using Clinic_Api.Application.Dto;
using Clinic_Api.Application.Exceptions;
using Clinic_Api.Application.Paging;
using Clinic_Api.Application.Queries.GetPatientById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
                var data = await _mediator.Send(new GetPatientByIdQuery(Id));

                return data;
            }
            catch (NotFoundException ex)
            {

                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreatePatient(CreatePatientRequestDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreatePatientCommandRequest(dto));

                return id;
            }
            catch (AlreadyExistsException ex)
            {

                StatusCode(403, ex.Message);
            }
            catch (Exception)
            {

                StatusCode(500);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeletePatient([FromRoute] string Id)
        {
            try
            {
                await _mediator.Send(new DeletePatientCommandRequest(Id));

                return StatusCode(204);
            }
            catch (NotFoundException ex)
            {

                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<string>> EditPatientPersonalData([FromRoute] string Id, [FromBody]  EditPatientPersonalDataRequestDto editPatientDataRequestDto)
        {
            try
            {
                var id = await _mediator.Send(new EditPatientPersonalDataCommandRequest(editPatientDataRequestDto, Id));

                return id;
            }
            catch (NotFoundException ex)
            {

                return StatusCode(404, ex.Message) ;
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
