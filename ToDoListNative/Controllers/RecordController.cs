using Microsoft.AspNetCore.Mvc;
using ToDoListNative.Domain.CoresInterfaces;
using ToDoListNative.Domain.Models.Request;
using ToDoListNative.Domain.Models.Response;

namespace ToDoListNative.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordController : ControllerBase
    {
        private readonly IRecordCors _recordCors;
        public RecordController(IRecordCors recordCors) 
        {
            _recordCors = recordCors;
        }

        [HttpGet("getRecord")]
        public async Task<ActionResult<GetRecordInfoResponse>> GetRecord(int id)
        {
            try
            {
                var record = await _recordCors.GetRecord(id);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("getRecords")]
        public ActionResult<GetRecordsResponse> GetRecords(FilterRecordsRequest request)
        {
            try
            {
                var records = _recordCors.GetRecords(request);
                return Ok(records);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("createRecord")]
        public async Task<ActionResult<GetRecordInfoResponse>> CreateRecord(CreateRecordRequest request)
        {
            try
            {
                var record = await _recordCors.CreateRecord(request);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("updateRecord")]
        public async Task<ActionResult<GetRecordInfoResponse>> UpdateRecord(UpdateRecordRequest request)
        {
            try
            {
                var record = await _recordCors.UpdateRecord(request);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("statusChangeRecord")]
        public async Task<ActionResult> StatusChangeRecord(ChangeStatusRecordRequest request)
        {

            try
            {
                await _recordCors.StatusChangeRecord(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("deleteRecord")]
        public async Task<ActionResult> DeleteRecord(int id)
        {
            try
            {
                await _recordCors.DeleteRecord(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
