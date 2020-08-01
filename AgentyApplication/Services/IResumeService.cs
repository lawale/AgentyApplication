using AgentyApplication.Models.Payloads;
using AgentyApplication.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyApplication.Services
{
    public interface IResumeService
    {
        Task<ObjectResource<ResumeResource>> CreateResumeAsync(ResumePayload payload);

        Task<ObjectResource<ResumeResource>> GetResumeByIdAsync(Guid resumeId);
    }
}
