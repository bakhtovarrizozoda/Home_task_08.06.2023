using Domain.Dtos;
using Infrastructure.Services.JobService;
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers;

public class JobController : Controller
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    } 
    
    [HttpGet]
    public IActionResult Index()
    {
        var result = _jobService.GetJobs();
        return View(result);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View(new JobDto());
    }

    [HttpPost]
    public IActionResult Create(JobDto job)
    {
        if (ModelState.IsValid)
        {
            _jobService.AddJob(job);
            return RedirectToAction("Index");
        }
        else
        {
            return View(job);
        }
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var updat = _jobService.GetJobById(id);
        var result = (new JobDto()
        {
            Id = updat.Id,
            Title = updat.Title,
            ClosingData = updat.ClosingData,
            CategoryId = updat.CategoryId,
            City = updat.City,
            Text = updat.Text
        });
        return View(result);
    }

    [HttpPost]
    public IActionResult Update(JobDto job)
    {
        if (ModelState.IsValid)
        {
            _jobService.UpdateJob(job);
            return RedirectToAction("Index");
        }
        else
        {
            return View(job);
        }
    }
    
    public  IActionResult Delete(int id)  
    {
        _jobService.DeleteJob(id);
        return RedirectToAction("Index");  
    }
    
}