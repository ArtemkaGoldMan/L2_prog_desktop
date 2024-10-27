using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Notification
{
    public interface INotification
    {
        Task SendAsync(string message);
    }
}
