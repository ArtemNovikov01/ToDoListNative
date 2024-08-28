using Microsoft.AspNetCore.Mvc;
using ToDoListNative.Domain.Models.Request;
using ToDoListNative.Domain.Models.Response;

namespace ToDoListNative.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetRecordInfoResponse>> GetRecord(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<GetRecordResponse>> GetRecords(FilterRecordsRequest request)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateRecord(CreateRecordRequest request)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<GetRecordInfoResponse>> UpdateRecord(UpdateRecordRequest request)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> CompleteRecord(int id)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRecord(int id)
        {
            return Ok();
        }
    }
}
