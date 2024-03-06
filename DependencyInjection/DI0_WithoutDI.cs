using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DependencyInjection
{
    public class MessageService
    {
        private readonly Logger _logger;

        public MessageService()
        {
            _logger = new Logger();
        }

        public void SendMessage(string message)
        {
            _logger.Log("Sending message: " + message);
            Console.WriteLine("Message sent: " + message);
        }
    }

    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging: " + message);
        }
    }
    public class DI0_WithoutDI
    {
        //Dette betyder, at MessageService er direkte afhængig af 
        //Logger-klassen.Hvis du senere vil ændre eller udskifte 
        //Logger-implementeringen, skal du ændre koden i 
        //MessageService-klassen, hvilket kan bryde åben/lukket-princippet 
        //og gøre din kode mere kompleks og mindre fleksibel.
        public static void Run()
        {
            // Opret en MessageService-instans
            MessageService messageService = new MessageService();

            // Brug MessageService til at sende en besked
            messageService.SendMessage("Hello, World!");
        }

    }
}
