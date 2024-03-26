using Clinic_Api.Application.Commands.CreatePatient;
using Clinic_Api.Application.Commands.DeletePatient;
using Clinic_Api.Application.Commands.EditPatientPersonalData;
using Clinic_Api.Application.Dto;
using Clinic_Api.Application.Exceptions;
using Clinic_Api.Application.Paging;
using Clinic_Api.Application.Queries.GetPatientBadge;
using Clinic_Api.Application.Queries.GetPatientById;
using Clinic_Api.Application.Queries.GetPatientByText;
using Clinic_Api.Application.Queries.GetPatientMetadata;
using Clinic_Api.Application.Queries.GetPatients;
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

        /// <summary>
        /// Getting single patient data by his Id
        /// </summary>
        /// <param name="Id">Id of a Patient</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPatientResponseDto>> GetPatientById([FromRoute] string Id)
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

        /// <summary>
        /// Getting metadata of the specified patient document stored in db with datetimes in utc
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Metadata")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPatientMetadataResponseDto>> GetPatientMetadataById([FromRoute] string Id)
        {
            try
            {
                var data = await _mediator.Send(new GetPatientMetadataQuery(Id));

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

        /// <summary>
        /// Getting list of patients, depends on parameters from pagination
        /// </summary>
        /// <param name="paginationParameters"></param>
        /// <returns></returns>
        [HttpGet("Pagination")]
        public async Task<ActionResult<List<GetPatientResponseDto>>> GetPaginatedPatients([FromQuery] PaginationParameters paginationParameters)
        {
            try
            {
                var data = await _mediator.Send(new GetPatientsQuery(paginationParameters));
                return Ok(data);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Getting List of patients matching the text query
        /// </summary>
        /// <param name="textQuery">Either first name, last name or both, separated by single space</param>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<ActionResult<List<GetPatientResponseDto>>> SearchForPatients([FromQuery] string textQuery)
        {
            try
            {
                var data = await _mediator.Send(new GetPatientsByTextQuery(textQuery));

                return data;
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }


        /// <summary>
        /// Getting zpl command template with values correct for patient with specified Id, you can find how it looks like in
        /// at https://labelary.com/viewer.html. Copy returned value, paste it in input, then redraw
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Badge")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPatientBadgeResponseDto>> GetPatientBadge([FromRoute] string Id)
        {
            try
            {
                var data = await _mediator.Send(new GetPatientBadgeQuery(Id));

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

        /// <summary>
        /// Creating patient with specified parameters
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<string>> CreatePatient(CreatePatientRequestDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreatePatientCommandRequest(dto));

                return id;
            }
            catch (AlreadyExistsException ex)
            {

                return StatusCode(403, ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        /// Deleting patient with specified Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Edition of Patient data, I decided to use PUT here
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="editPatientDataRequestDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
