using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApplication.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected async Task<IActionResult> ExecuteWithErrorHandlingAsync(Func<Task<IActionResult>> action)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                return await action().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                return StatusCode(500);
            }
        }

        private void ProcessException(Exception ex)
        {
            //logging and etc
            throw new NotImplementedException();
        }
    }
}
