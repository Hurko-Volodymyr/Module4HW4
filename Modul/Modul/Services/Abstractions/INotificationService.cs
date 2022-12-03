using Module.Models;

namespace Module.Services.Abstractions;

public interface INotificationService
{
    void Notify(NotifyType type, string massage, string to);
}