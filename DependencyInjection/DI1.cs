using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DependencyInjection
{

    //Først skal du installere pakken via NuGet-pakken
    //Microsoft.Extensions.DependencyInjection
    public interface IGreetingProvider
    {
        string GetGreeting();
    }

    public class GreetingProvider : IGreetingProvider
    {
        public string GetGreeting()
        {
            return "Hello, World!";
        }
    }

    //Her er et eksempel, hvor vi har en simpel
    //service GreetingService, 
    //som afhænger af en IGreetingProvider:
    public class GreetingService
    {
        private readonly IGreetingProvider _greetingProvider;

        public GreetingService(IGreetingProvider greetingProvider)
        {
            _greetingProvider = greetingProvider;
        }

        public void Greet()
        {
            string greeting = _greetingProvider.GetGreeting();
            Console.WriteLine(greeting);
        }
    }
    public static class DI1
    {

        //I dette eksempel konfigurerer vi en tjenestesamling(ServiceCollection), 
        //registrerer vores tjenester(GreetingProvider og GreetingService) 
        //og bygger derefter en tjenesteudbyder(IServiceProvider). Når vi har
        //oprettet GreetingService ved hjælp af tjenesteudbyderen,
        //bliver GreetingProvider automatisk injiceret i dens konstruktør.
        //Når Greet()-metoden kaldes, bruger den IGreetingProvider-tjenesten
        //til at hente hilsenen og udskrive den.Denne tilgang giver løs kobling
        //mellem GreetingService og GreetingProvider, hvilket gør det lettere
        //at teste og udskifte komponenter.
        public static void Run()
        {
            // Opret en Service Collection
            var services = new ServiceCollection();

            // Tilføj tjenester til containeren
            services.AddTransient<IGreetingProvider, GreetingProvider>();
            services.AddTransient<GreetingService>();

            // Bygge serviceudbyderen
            var serviceProvider = services.BuildServiceProvider();

            // Hent GreetingService fra containeren
            var greetingService = serviceProvider.GetRequiredService<GreetingService>();

            // Brug tjenesten
            greetingService.Greet();
        }
// Der er flere fordele ved at anvende Dependency Injection(DI)
// i dette eksempel:
// Løs kobling: Ved at bruge DI holdes klasserne løst koblet.
//              GreetingService kender kun til IGreetingProvider-interfacet,
//              ikke den konkrete implementering GreetingProvider.
//              Dette gør det lettere at ændre eller udskifte GreetingProvider
//              -implementeringen uden at ændre noget i GreetingService.
// Testbarhed: Da afhængigheder injiceres i klassen, er det nemt at teste
//             klassen ved at erstatte de faktiske implementeringer med stubs,
//             mockobjekter eller simulerede objekter under testene.
//             Dette gør enhedstestning mere robust og lettere.
// Genbrugelighed: Komponenterne bliver mere genanvendelige, da de ikke er
//             bundet til specifikke implementeringer af deres afhængigheder.
//             Det betyder, at en service som GreetingService kan genbruges
//             i andre dele af applikationen eller endda i forskellige
//             applikationer, så længe de nødvendige afhængigheder injiceres
//             korrekt.
//Lettere vedligeholdelse: DI gør det lettere at vedligeholde koden ved at
//             skille sig ud af ansvar og bekymringer. Hver klasse har sit
//             eget område af ansvar, hvilket gør det nemmere at forstå og
//             vedligeholde koden over tid.

//Samlet set gør brugen af Dependency Injection i dette eksempel koden mere fleksibel, testbar og lettere at vedligeholde, samtidig med at den reducerer koblingen mellem komponenterne.


    }
}
