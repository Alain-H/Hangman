using System;

namespace Math_Klassen
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("###HANGMAN###");
                Console.WriteLine("#############");
                Console.WriteLine();

                Console.WriteLine("Wählen eine Aktion aus:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] Spielen");
                Console.WriteLine("[2] Beenden");
                Console.ResetColor();
                Console.WriteLine();

                Console.Write("Aktion: ");
                int auswahl = Convert.ToInt32(Console.ReadLine());
                bool end = false;

                switch (auswahl)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        end = true;
                        break;
                }
                if (end)
                {
                    break;
                }
                        
                
                Console.Clear();
                
            }
            static void StartGame()
            {
                string[] words = new string[]
                {
                    "Apfelkuchen",
                    "Gemüsesuppe",
                    "Kraftfahrzeug",
                    "Lastwagen",
                    "Videospiel",
                    "Alarmanlage",
                    "Vollkornbrot"
                };

                Random rnd = new Random();
                int index = rnd.Next(0, words.Length);
                string word = words[index].ToLower();
                GameLoop(word);

            }

            static void GameLoop(string word)
            {
                int lives = 10;
                string hiddenWord = "";
                
                for(int i =0; i < word.Length; i++)
                {
                    hiddenWord += "_";
                }

                while(true)
                {
                    Console.Clear();
                    Console.WriteLine("Gesuchtes Wort: {0}", hiddenWord);
                    Console.Write("Noch übrige Versuche: ");
                    for(int i = 0; i < lives; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                    Console.Write("Buchstabe: ");
                    char charakter = Convert.ToChar(Console.ReadLine().ToLower());

                    bool foundCharakterInWord = false;
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == charakter)
                        {
                            foundCharakterInWord = true;
                            break;

                        }
                    }

                    string tempHiddenWord = hiddenWord;
                    hiddenWord = "";

                    if (foundCharakterInWord)
                    {
                        for(int i = 0; i< word.Length;i++)
                        {
                            if (word[i]== charakter)
                            {
                                hiddenWord += charakter;
                            }
                            else if (tempHiddenWord[i] != '_')
                            {
                                hiddenWord += tempHiddenWord[i];
                            }
                            else
                            {
                                hiddenWord += '_';
                            }
                        }

                        if (hiddenWord == word)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("GEWONNEN!!!");
                            Console.WriteLine("Das Wort war: "+word);
                            Console.ReadKey();
                            Console.ResetColor();
                            break;
                        }
                            
                            
                    }
                    else
                    {
                        hiddenWord = tempHiddenWord;
                        
                        if(lives >0)
                        {
                            lives -= 1;
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("GAME OVER!!!");
                            Console.ReadKey();
                            Console.ResetColor();
                            break;
                        }
                    }
                }
            }
        }
    }
}
