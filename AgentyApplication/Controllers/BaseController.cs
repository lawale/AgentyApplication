using AgentyApplication.Models.Resources;
using Microsoft.AspNetCore.Mvc;
using static AgentyApplication.Models.Constants.ResponseCodes;

namespace AgentyApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ActionResult<TRes> HandleResponse<TRes>(TRes result) where TRes : StatusResource
        {
            if (result.Code == NoData) return NotFound(result);
            if (result.Code == Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
