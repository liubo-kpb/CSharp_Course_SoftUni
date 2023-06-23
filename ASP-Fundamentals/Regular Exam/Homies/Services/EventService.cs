namespace Homies.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Data;
using Models;
using Interfaces;
using Data.Entities;

public class EventService : IEventService
{
    private readonly HomiesDbContext _dbContext;

    public EventService(HomiesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddEvent(FormEventViewModel newEvent, string userId)
    {
        var dbEvent = new Event()
        {
            Name = newEvent.Name,
            Description = newEvent.Description,
            Start = newEvent.Start,
            End = newEvent.End,
            TypeId = newEvent.TypeId,
            OrganiserId = userId
        };

        await _dbContext.Events.AddAsync(dbEvent);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditEvent(FormEventViewModel editedEvent, int id)
    {
        var dbEvent = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

        dbEvent.Name = editedEvent.Name;
        dbEvent.Description = editedEvent.Description;
        dbEvent.Start = editedEvent.Start;
        dbEvent.End = editedEvent.End;
        dbEvent.TypeId = editedEvent.TypeId;

        await _dbContext.SaveChangesAsync();
    }

    public async Task<DetailsEventViewModel> GetEventById(int id)
    {
        var dbEvent = await _dbContext.Events
            .Include(e => e.Organiser)
            .Include(e => e.Type)
            .FirstOrDefaultAsync(e => e.Id == id);

        var modelEvent = new DetailsEventViewModel()
        {
            Id = dbEvent.Id,
            Name = dbEvent.Name,
            Description = dbEvent.Description,
            Start = dbEvent.Start,
            End = dbEvent.End,
            Organiser = dbEvent.Organiser.UserName,
            CreatedOn = dbEvent.CreatedOn,
            Type = dbEvent.Type.Name
        };

        return modelEvent;
    }

    public async Task<IEnumerable<EventViewModel>> GetEvents()
    {
        var events = _dbContext.Events
            .Include(e => e.Type)
            .Include(e => e.Organiser)
            .Select(e => new EventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start,
                Type = e.Type.Name,
                Organiser = e.Organiser.UserName
            }).AsEnumerable();

        return events;
    }

    public async Task JoinEvent()
    {
        throw new NotImplementedException();
    }

    public async Task RemoveEvent()
    {
        throw new NotImplementedException();
    }
}
