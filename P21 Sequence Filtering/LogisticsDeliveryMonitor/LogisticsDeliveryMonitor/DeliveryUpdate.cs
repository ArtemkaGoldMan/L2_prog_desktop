using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsDeliveryMonitor
{
    public class DeliveryUpdate
    {
        public string? RouteId { get; set; }
        public string? Status { get; set; } // "on-time", "delayed", "completed"
        public DateTime Eta { get; set; }
        public string? Location { get; set; }
    }
}
