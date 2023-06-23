namespace Homies.Services.Interfaces;

using Homies.Models;

public interface IEventService
{
    public Task<IEnumerable<EventViewModel>> GetEvents();
    public Task<DetailsEventViewModel> GetEventById(int id);

    public Task JoinEvent();

    public Task AddEvent(FormEventViewModel newEvent, string userId);

    public Task RemoveEvent();

    public Task EditEvent(FormEventViewModel editedEvent, int id);
}
