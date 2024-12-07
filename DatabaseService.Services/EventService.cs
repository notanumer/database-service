using DatabaseService.DataAccess.Abstractions;
using DatabaseService.DataAccess.RabbitMq;
using DatabaseService.Models.Postgres;
using DatabaseService.Models.Rabbit;
using Newtonsoft.Json;

namespace DatabaseService.Services.Abstractions;

public class EventService : IEventService
{
    private readonly IAppDbContext _appDbContext;
    private readonly IRabbitMqService _rabbitMqService;

    public EventService(IRabbitMqService rabbitMqService, IAppDbContext appDbContext)
    {
        _rabbitMqService = rabbitMqService;
        _appDbContext = appDbContext;
    }

    public async Task SendEventAsync(Event notificationEvent, CancellationToken cancellationToken = default)
    {
        var message = JsonConvert.SerializeObject(notificationEvent);
        var isSuccess = await _rabbitMqService.SendMessageAsync(message, cancellationToken);

        var notification = new Notification()
        {
            MessageContent = notificationEvent.MessageContent.Text,
            MessageType = notificationEvent.EventType,
            Recipient = notificationEvent.Recipient,
            IsSuccess = isSuccess,
            CreatedAt = DateTimeOffset.Now,

        };

        await _appDbContext.Notifications.AddAsync(notification, cancellationToken);
    }
}