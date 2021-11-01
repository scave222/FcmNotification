using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FcmNotification.Model
{
    public class SendNotification
    {
        public string deviceId { get; set; }
        public string message { get; set; }
        public string timestamp { get; set; }
        public string notificationEvent { get; set; }
        public string image { get; set; }
        public string title { get; set; }
    }
}
