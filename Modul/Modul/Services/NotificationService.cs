using Module.Models;
using Module.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace Module.Services;

public class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> _loggerService;

    public NotificationService(ILogger<NotificationService> loggerService)
    {
        _loggerService = loggerService;
    }

    public void Notify(NotifyType type, string massage, string to)
    {
        _loggerService.LogInformation($"Notification was sent for {type}");
    }
}