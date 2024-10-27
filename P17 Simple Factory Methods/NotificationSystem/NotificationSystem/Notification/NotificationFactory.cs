using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Notification
{
    public static class NotificationFactory
    {
        public static INotification CreateNotification(string notificationType)
        {
            return notificationType.ToLower() switch
            {
                "email" => new EmailNotification(),
                "sms" => new SmsNotification(),
                "push" => new PushNotification(),
                _ => throw new NotSupportedException("Unsupported notification type")
            };
        }
    }
}
