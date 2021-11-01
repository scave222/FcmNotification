using FcmNotification.Model;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FcmNotification.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FcmNotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("PushNotification")]
        public async void PushNotification(SendNotification notification)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("private_key.json")
            });

            // message payload
            var message = new Message()
            {
                Token = notification.deviceId,

                Notification = new Notification()
                {
                    Title = notification.title,
                    Body = notification.message,
                    ImageUrl = notification.image
                }
            };

            //Send a message to the device corresponding to the provided registartion token
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}
