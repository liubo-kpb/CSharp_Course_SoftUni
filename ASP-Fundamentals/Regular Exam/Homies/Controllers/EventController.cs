namespace Homies.Controllers;

using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using Models;
using Services.Interfaces;

public class EventController : Controller
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public IActionResult All()
    {
        var events = _eventService.GetEvents().Result;

        return View(events);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(FormEventViewModel newEvent)
    {
        if (!ModelState.IsValid)
        {

        }

        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        await _eventService.AddEvent(newEvent, userId);

        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var eventModel = _eventService
            .GetEvents()
            .Result
            .FirstOrDefault(e => e.Id == id);

        return View(eventModel);
    }

    [HttpPatch]
    public async Task<IActionResult> Edit(FormEventViewModel editedEvent, int id)
    {
        await _eventService.EditEvent(editedEvent, id);

        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var modelEvent = await _eventService.GetEventById(id);

        return View(modelEvent);
    }
}
