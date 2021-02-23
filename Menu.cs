using System;
using System.Collections.Generic;
using System.Text;

namespace SQL_Assignment1
{
    class Menu
    {
        public static void ShowFirstMenu()
        {
            Console.WriteLine("________________________________");
            Console.WriteLine("|1. Skapa databas              |");
            Console.WriteLine("|2. Använd en befintlig databas|");
            Console.WriteLine("|3. Gå till inlämningsuppgiften|");
            Console.WriteLine("|q. Avsluta programmet         |");
            Console.WriteLine("|______________________________|");
            Console.Write("Ange ditt val: ");
        }

        public static void ShowSM()
        {
            Console.WriteLine("________________________________");
            Console.WriteLine("|1. Skapa en tabell            |");
            Console.WriteLine("|2. Använd en befintlig tabell |");
            Console.WriteLine("|3. Radera en tabell           |");
            Console.WriteLine("|q. Gå till huvudmenyn         |");
            Console.WriteLine("|______________________________|");
            Console.Write("Ange ditt val: ");
        }

        public static void ShowCRUD()
        {
            Console.WriteLine("________________________________");
            Console.WriteLine("|1. Skapa ett objekt           |");
            Console.WriteLine("|2. Redigera ett objekt        |");
            Console.WriteLine("|3. Radera ett objekt          |");
            Console.WriteLine("|4. Skriv ut tabellen          |");
            Console.WriteLine("|q. Gå tillbaka i menun        |");
            Console.WriteLine("|______________________________|");
            Console.Write("Ange ditt val: ");
        }
    }
}
