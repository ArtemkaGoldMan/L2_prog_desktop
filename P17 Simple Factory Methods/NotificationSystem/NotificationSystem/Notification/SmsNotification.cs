﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Notification
{
    public class SmsNotification : INotification
    {
        public async Task SendAsync(string message)
        {
            await Task.Delay(500);
            Console.WriteLine($"SMS sent: {message}");
        }
    }
}
