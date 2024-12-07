using DatabaseService.Models.Rabbit;
using DatabaseService.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers;

[Route("event")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost("send")]
    public async Task SendEvent(Event notificationEvent, CancellationToken cancellationToken)
        => await _eventService.SendEventAsync(notificationEvent, cancellationToken);
}