using AgentyApplication.Domains;
using AgentyApplication.Models.Constants;
using AgentyApplication.Models.Options;
using AgentyApplication.Models.Payloads;
using AgentyApplication.Models.Resources;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyApplication.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IDatabaseSettings databaseSettings;

        private IMongoCollection<Resume> resumes;

        public ResumeService(IDatabaseSettings databaseSettings)
        {
            this.databaseSettings = databaseSettings;
            GetResumeCollection();
        }

        public async Task<ObjectResource<ResumeResource>> CreateResumeAsync(ResumePayload payload)
        {
            var resume = new Resume { Experience = payload.Experience, Location = payload.Location, Id = Guid.NewGuid().ToString(), Name = payload.Name, PhoneNumber = payload.PhoneNumber, Skills = payload.Skills };
            await resumes.InsertOneAsync(resume);
            
            return new ObjectResource<ResumeResource> { Code = ResponseCodes.Success, Data = CreateResumeResource(resume), Message = "Resume Successfully Stored" };
        }

        public async Task<ObjectResource<ResumeResource>> GetResumeByIdAsync(Guid resumeId)
        {
            var resumeCursor = await resumes.FindAsync(x => x.Id == resumeId.ToString());
            var resume = await resumeCursor.FirstOrDefaultAsync();
            if (resume is null) return new ObjectResource<ResumeResource> { Code = ResponseCodes.NoData, Message = "Resume Does Not Exist" };

            return new ObjectResource<ResumeResource> { Code = ResponseCodes.Success, Data = CreateResumeResource(resume), Message = "Resume Found" };
        }

        private ResumeResource CreateResumeResource(Resume resume)
        {
            var resource = new ResumeResource 
            { 
                Experience = resume.Experience,
                Location = resume.Location, 
                Name = resume.Name, 
                ResumeId = resume.Id, 
                PhoneNumber = resume.PhoneNumber, 
                Skills = resume.Skills 
            };
            return resource;
        }

        private IMongoCollection<Resume> GetResumeCollection()
        {
            if (resumes is { }) return resumes;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            return resumes = database.GetCollection<Resume>(databaseSettings.CollectionName);
        }
    }
}
