using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeechCorrection.APIs.Errors;

namespace SpeechCorrection.APIs.Controllers
{
    [Route("error/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {

        [HttpGet]
        public ActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
