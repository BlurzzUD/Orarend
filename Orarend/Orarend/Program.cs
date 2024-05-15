using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Title = "Orarend Deak 6/C";
        try
        {
            Dictionary<string, Dictionary<string, string>> dayToFile = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "A", new Dictionary<string, string>
                    {
                        { "Hetfo", "hetfoa.txt" },
                        { "Kedd", "kedda.txt" },
                        { "Szerda", "szerdaa.txt" },
                        { "Csutortok", "csutortoka.txt" },
                        { "Pentek", "penteka.txt" }
                    }
                },
                {
                    "B", new Dictionary<string, string>
                    {
                        { "Hetfo", "hetfob.txt" },
                        { "Kedd", "keddb.txt" },
                        { "Szerda", "szerdab.txt" },
                        { "Csutortok", "csutortokb.txt" },
                        { "Pentek", "pentekb.txt" }
                    }
                }
            };

            Console.Write("A vagy B hét legyen? : ");
            string option = Console.ReadLine().ToUpper();

            if (dayToFile.ContainsKey(option))
            {
                var fileDictionary = dayToFile[option];

                while (true)  
                {
                    Console.Write("Melyik nap legyen: ");
                    string userInput = Console.ReadLine().Trim().ToLower();

                    if (userInput == "segitseg")
                    {
                        Console.WriteLine("Hogy a napokat Nagy betűvel meg ékezet nélkül kell írni pl Hetfo");
                        continue;  
                    }

                    userInput = CapitalizeFirstLetter(userInput);

                    if (fileDictionary.ContainsKey(userInput))
                    {
                        string fileName = fileDictionary[userInput];

                        if (File.Exists(fileName))
                        {
                            string fileContent = File.ReadAllText(fileName);
                            Console.WriteLine($"It van az órarend");
                            Console.WriteLine(fileContent);
                        }
                        else
                        {
                            Console.WriteLine($"A {fileName} fájl nem található.");
                        }
                        break;  
                    }
                    else
                    {
                        Console.WriteLine("Nem jó nap, próbáld újra.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Érvénytelen választás");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba történt: {ex.Message}");
        }

        Console.WriteLine("Nyomja meg bármelyik billentyűt a kilépéshez...");
        Console.ReadKey();
    }

    // Helper function to capitalize the first letter
    static string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;
        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }
}
