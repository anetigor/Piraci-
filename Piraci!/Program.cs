using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kapitan kapitan = new Kapitan();

            
            
                kapitan.ZarejestrujDelegata(Marynarz.OdebranoRozkaz);
                kapitan.ZarejestrujDelegata(Okretowy.OdebranoRozkaz);
                
                
                kapitan.WydajRozkaz();
            

        }
    }
    enum Rozkaz
    {
        prawa,
        lewa,
        salwa,
        zwrot
    }

    
    delegate void OdebranoRozkazDelegate(Rozkaz rozkaz);

    
    class Kapitan
    {
        private Rozkaz aktualnyRozkaz;
        private OdebranoRozkazDelegate odebranoRozkazDelegate;

       
        public void ZarejestrujDelegata(OdebranoRozkazDelegate delegat)
        {
            odebranoRozkazDelegate += delegat;
        }

       
        public void WydajRozkaz()
        {
            
            Random random = new Random();
            int rozkazIndex = random.Next(0, Enum.GetValues(typeof(Rozkaz)).Length);
            aktualnyRozkaz = (Rozkaz)rozkazIndex;

            
            odebranoRozkazDelegate?.Invoke(aktualnyRozkaz);
        }
    }

   
    class Marynarz
    {
        public static void OdebranoRozkaz(Rozkaz rozkaz)
        {
            Console.WriteLine("Rozkaz przyjęty Panie Kapitanie: " + rozkaz);

            if (rozkaz == Rozkaz.salwa)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BUM BUM BUM");
                Console.ResetColor();
            }
        }
    }

    class Okretowy
    {
        public static void OdebranoRozkaz(Rozkaz rozkaz)
        {
            Console.WriteLine("Tak jest Panie Kapitanie: " + rozkaz);
        }
    }

}