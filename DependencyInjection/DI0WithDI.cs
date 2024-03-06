using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    
    public class DI0WithDI
    {
        

        public interface ILogger
        {
            void Log(string message);
        }

        public class Logger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("Logging: " + message);
            }
        }

        public class MessageService
        {
            private readonly ILogger _logger;

            public MessageService(ILogger logger)
            {
                _logger = logger;
            }

            public void SendMessage(string message)
            {
                _logger.Log("Sending message: " + message);
                Console.WriteLine("Message sent: " + message);
            }
        }
        //I dette eksempel indsprøjter vi en Logger-instans i 
        //MessageService ved hjælp af konstruktørinjektion.
        //Dette gør det muligt at udskifte Logger-implementeringen 
        //uden at ændre noget i MessageService-klassen, 
        //hvilket følger princippet om løs kobling.
        public static void Run()
        {
            // Opret en Logger-instans
            ILogger logger = new Logger();

            // Opret en MessageService-instans og injicer loggeren
            MessageService messageService = new MessageService(logger);

            // Brug MessageService til at sende en besked
            messageService.SendMessage("Hello, World!");
        }

    }
}
