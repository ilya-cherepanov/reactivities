using Microsoft.AspNetCore.Mvc;
using persistence;
using domain;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

public class ActivitiesController : BaseApiController
{
    private readonly DataContext _context;

    public ActivitiesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await _context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetOneActivity(Guid id)
    {
        var activity = await _context.Activities.FindAsync(id);

        if (activity is null)
        {
            return NotFound();
        }

        return activity;
    }
}