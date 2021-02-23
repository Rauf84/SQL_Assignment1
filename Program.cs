using System;
using System.ComponentModel.Design;
using System.Data;

namespace SQL_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string cname;
            string dtname;
            string firstmenuchoise = "";
            int dbchoise;
            Console.WriteLine("---Welcome---");
            while (firstmenuchoise != "q")
            {
                Menu.ShowFirstMenu();
                firstmenuchoise = Console.ReadLine();
                switch (firstmenuchoise)
                {

                    case "1":
                        Console.WriteLine("Vad ska databasen heta: ");
                        string checkName = Console.ReadLine();
                        
                        if (Database.CheckDatabaseExists(checkName) == false)
                        {
                            Database.CreateDatabase(checkName);
                        };
                        break;
                    case "2":
                        Console.WriteLine("-----Befintliga databaser-----");
                        Database.GetDBNames();
                        Console.Write("Vilken databas vill du använda dig av: ");
                        dbchoise = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Du har valt att använda {Database.DBNames[dbchoise-1]} databasen");
                        Database.dbname = Database.DBNames[dbchoise - 1];
                        Menu.ShowSM();
                        string secondmenuchoise = Console.ReadLine();
                        while (secondmenuchoise != "q")
                        {
                            switch (secondmenuchoise)
                            {
                                case "1":
                                    
                                    Console.Write("Vad ska tabellen heta: ");
                                    dtname = Console.ReadLine();
                                    cname = "";
                                    string answ = "y";
                                    while (answ == "y")
                                    {
                                        Console.Write("Lägg till en kolumn: ");
                                        cname = cname + Console.ReadLine();
                                        Console.WriteLine($"Välj en datatyp för kolumn {cname}");
                                        Console.WriteLine("1. int");
                                        Console.WriteLine("2. varchar (50)");
                                        Console.WriteLine("3. int NOT NULL PRIMARY KEY");
                                        Console.Write("Val av datatyp: ");
                                        string dtype = Console.ReadLine();
                                        if (dtype == "1")
                                        {
                                            cname = cname + " int";
                                        }
                                        else if (dtype == "2")
                                        {
                                            cname = cname + " varchar(50)";
                                        } else cname = cname + " int NOT NULL PRIMARY KEY";
                                        Console.Write("Vill du lägga en till kollumn (y/n)? ");
                                        answ = Console.ReadLine();
                                        if (answ == "y")
                                        {
                                            cname = cname + ",";
                                        }
                                        else secondmenuchoise = "q";
                                    }
                                    Database.CreateDataTable(dtname, cname);
                                    break;
                                case "2":
                                    Database.GetDTNames(Database.dbname);
                                    Console.Write("Vilken tabell du vill använda: ");
                                    secondmenuchoise = Console.ReadLine();
                                    Console.WriteLine($"Du har valt tabell {Database.DTNames[Convert.ToInt32(secondmenuchoise)-1]}");
                                    Database.GetColumns($"{ Database.DTNames[Convert.ToInt32(secondmenuchoise) - 1]}");
                                    Database.PrintTable($"{Database.DTNames[Convert.ToInt32(secondmenuchoise)-1]}");
                                    string crudmenuchoise = "";
                                    while (crudmenuchoise != "q")
                                    {
                                        Menu.ShowCRUD();
                                        crudmenuchoise = Console.ReadLine();
                                        switch (crudmenuchoise)
                                        {
                                            case "1":
                                                CRUD.CreateObject($"{Database.DTNames[Convert.ToInt32(secondmenuchoise) - 1]}");
                                                Console.WriteLine("Objekt har skapats");
                                                break;
                                            case "2":
                                                CRUD.ChangeObject($"{Database.DTNames[Convert.ToInt32(secondmenuchoise) - 1]}");
                                                Console.WriteLine("Objekt har redigerats");
                                                break;
                                            case "3":
                                                Console.Write("VIlket objekt vill du radera, ID: ");
                                                CRUD.DeleteObject($"{Database.DTNames[Convert.ToInt32(secondmenuchoise) - 1]}", $"{Console.ReadLine()}");
                                                break;
                                            case "4":
                                                Database.PrintTable(Database.DTNames[Convert.ToInt32(secondmenuchoise) - 1]);
                                                break;
                                            case "q":
                                                secondmenuchoise = "q";

                                                break;
                                            default: 
                                                Console.WriteLine("Fel val, försök igen!");
                                                break;
                                        }

                                    }
                                    break;
                                case "q":
                                    break;
                            }
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Hej och välkommen till inlämningsuppgiften 'My Family Tree'");
                        Console.WriteLine("Databasen MyFamTree har skapats i första menuvalet med alla tabeller som används i uppgiften");
                        break;
                    case "q":
                        Console.WriteLine("Programmet avslutas ... Välkommen tillbaka");
                        break;
                }

            }
            
        }
    }
}
