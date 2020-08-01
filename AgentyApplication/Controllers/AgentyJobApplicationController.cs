using AgentyApplication.Models.Payloads;
using AgentyApplication.Models.Resources;
using AgentyApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgentyApplication.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AgentyJobApplicationController : BaseController
    {
        private readonly IResumeService resumeService;

        public AgentyJobApplicationController(IResumeService resumeService)
        {
            this.resumeService = resumeService;
        }

        /// <summary>
        /// Creates a resume
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ObjectResource<ResumeResource>>> CreateResume([FromBody] ResumePayload payload)
        {
            var result = await resumeService.CreateResumeAsync(payload);
            return HandleResponse(result);
        }

        /// <summary>
        /// Returns a resume by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectResource<ResumeResource>>> GetResumeById(Guid id)
        {
            var result = await resumeService.GetResumeByIdAsync(id);
            return HandleResponse(result);
        }
    }
}
