using Dapper;
using Domain.Dtos;
using Infrastructure.Cantext;

namespace Infrastructure.Services.JobService;

public class JobService : IJobService
{
    private readonly DapperContext _context;

    public JobService(DapperContext context)
    {
        _context = context;
    }
    public List<JobDto> GetJobs()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, title as Title, closing_data as ClosingData, category_id as CategoryId, city as City, text as Text from jobs order by id";
            var result = conn.Query<JobDto>(sql);
            return result.ToList();
        }
    }

    public List<JobDto> GetJobByName(string name)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, title as Title, closing_data as ClosingData, category_id as CategoryId, city as City, text as Text from jobs where title like '%{name}%' ";
            var result = conn.Query<JobDto>(sql).ToList();
            return result;
        }
    }

    public JobDto GetJobById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, title as Title, closing_data as ClosingData, category_id as CategoryId, city as City, text as Text from jobs where id = @Id";
            var result = conn.QuerySingleOrDefault<JobDto>(sql, new {Id});
            return result;
        }
    }

    public JobDto AddJob(JobDto job)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into jobs(title, closing_data, category_id, city, text) values (@Title, @ClosingData, @CategoryId, @City, @Text) returning id";
            var result = conn.ExecuteScalar<int>(sql, job);
            job.Id = result;
            return job;
        }
    }

    public JobDto UpdateJob(JobDto job)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"update jobs set title = @Title, closing_data = @ClosingData, category_id = @CategoryId, city = @City, text = @Text where id = @Id";
            var result = conn.Execute(sql, job);
            return job;
        }
    }

    public bool DeleteJob(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"delete from jobs where id = @Id";
            var result = conn.Execute(sql, new {Id});
            if (result > 0) return true;
            else return false;
        }
    }
}