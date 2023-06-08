using Domain.Dtos;

namespace Infrastructure.Services.JobService;

public interface IJobService
{
    List<JobDto> GetJobs();
    List<JobDto> GetJobByName(string name);
    JobDto GetJobById(int Id);
    JobDto AddJob(JobDto job);
    JobDto UpdateJob(JobDto job);
    bool DeleteJob(int Id);
}