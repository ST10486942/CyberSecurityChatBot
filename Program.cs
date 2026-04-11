using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;
using static System.Console;

namespace CybersecurityChatBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            //Array of chatbot responses based on key words
            Dictionary<string, string[]> chatbot = new Dictionary<string, string[]>
            {
                

                { "purpose", new[]
                    {
                        "I am a cybersecurity chatbot designed to help you stay safe online.",
                        "My purpose is to protect users by giving cybersecurity advice.",
                        "I help you understand online threats and how to avoid them."
                    }
                },
                { "software", new[]
                    {
                        "Software development is the process of designing, building, testing, and maintaining applications.",
                        "It involves coding, testing, and improving programs.",
                        "Developers create software to solve real-world problems."
                    }
                },
                { "web", new[]
                    {
                        "Web development is about building websites and web apps.",
                        "It uses HTML, CSS, JavaScript, and backend technologies.",
                        "Web apps run in your browser and connect to servers."
                    }
                },
                { "array", new[]
                    {
                        "An array stores multiple values of the same type in one variable.",
                        "Arrays help manage lists of data efficiently.",
                        "Each value in an array has an index."
                    }
                },
                { "oop", new[]
                    {
                        "OOP stands for Object-Oriented Programming.",
                        "It uses classes and objects to structure code.",
                        "Key concepts include inheritance, encapsulation, and polymorphism."
                    }
                },
                { "debug", new[]
                    {
                        "Debugging is the process of finding and fixing errors in code.",
                        "It helps ensure your program runs correctly.",
                        "Developers use tools to trace and fix bugs."
                    }
                },

                { "How are you", new[]
                    {
                        "I am excited for today's session",
                        "I am happy today.",
                        "I am excited to assist you today."
                    }
                },
            };

            try
            {
                string asciiPath = @"C:\Users\Student\source\repos\Prog6221Assignment\AsciiArt.txt";
                string audioPath = @"C:\Users\Student\source\repos\Prog6221Assignment\GreetingRecording.wav";

                Clear();

                // Calling the method to display in ascii art
                if (File.Exists(asciiPath))
                {
                    string ascii = File.ReadAllText(asciiPath);
                    ForegroundColor = ConsoleColor.Cyan;

                    foreach (string line in ascii.Split('\n'))
                    {
                        int padding = (WindowWidth - line.TrimEnd().Length) / 2;
                        WriteLine(new string(' ', Math.Max(0, padding)) + line.TrimEnd());
                    }

                    ResetColor();
                }
                else
                {
                    WriteLine("ASCII file not found: " + asciiPath);
                }

                Thread.Sleep(800);

                if (File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.PlaySync();
                }
                else
                {
                    WriteLine("\nAudio file not found: " + audioPath);
                }


                Write("\nPlease enter your name: ");
                string username = ReadLine()?.Trim();

                if (string.IsNullOrEmpty(username))
                    username = "Friend";

                // Using the display in ascii method
                WriteLine();
                DisplayWelcomeWithNameInAscii("Welcome", username.ToUpper());

                WriteLine("\nWELCOME TO THE CYBER SECURITY CHATBOT!\n");
                WriteLine("Type 'exit' anytime to quit.\n");

                // Chat loop
                while (true)
                {
                    Write("\nYou: ");
                    string input = ReadLine().ToLower();

                    if (input == "exit")
                    {
                        WriteLine("Chatbot: Goodbye! Stay safe online 🔐");
                        break;
                    }

                    bool found = false;

                    foreach (var item in chatbot)
                    {
                        if (input.Contains(item.Key))
                        {
                            string[] replies = item.Value;
                            string response = replies[rand.Next(replies.Length)];

                            WriteLine("Chatbot: " + response);
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        string[] fallback =
                        {
                            "I'm not sure I understand. Try asking about cybersecurity or IT topics.",
                            "Can you rephrase that? I can help with IT and online safety.",
                            "That doesn't seem IT-related. Try asking about software, web, or security.",
                            "Interesting question! But I specialize in cybersecurity topics."
                        };

                        WriteLine("Chatbot: " + fallback[rand.Next(fallback.Length)]);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine("Error: " + ex.Message);
            }
        }

        // ASCII Method
        static void DisplayWelcomeWithNameInAscii(string welcomeText, string username)
        {
            var asciiArt = new Dictionary<char, string[]>
            {
                {'A', new[] { "  AAA  ", " A   A ", "AAAAAAA", "A     A", "A     A" }},
                {'B', new[] { "BBBBBB ", "B     B", "BBBBBB ", "B     B", "BBBBBB " }},
                {'C', new[] { " CCCCC ", "C     C", "C      ", "C     C", " CCCCC " }},
                {'D', new[] { "DDDDDD ", "D     D", "D     D", "D     D", "DDDDDD " }},
                {'E', new[] { "EEEEEEE", "E      ", "EEEEE  ", "E      ", "EEEEEEE" }},
                {'F', new[] { "FFFFFFF", "F      ", "FFFFF  ", "F      ", "F      " }},
                {'G', new[] { " GGGGG ", "G     G", "G   GGG", "G     G", " GGGGG " }},
                {'H', new[] { "H     H", "H     H", "HHHHHHH", "H     H", "H     H" }},
                {'I', new[] { " IIIII ", "  III  ", "  III  ", "  III  ", " IIIII " }},
                {'J', new[] { "   JJJ ", "    JJ ", "    JJ ", "J   JJ ", " JJJJ  " }},
                {'K', new[] { "K     K", "K    K ", "KKKKK  ", "K    K ", "K     K" }},
                {'L', new[] { "L      ", "L      ", "L      ", "L      ", "LLLLLLL" }},
                {'M', new[] { "M     M", "MM   MM", "M M M M", "M  M  M", "M     M" }},
                {'N', new[] { "N     N", "NN    N", "N N   N", "N  N  N", "N     N" }},
                {'O', new[] { " OOOOO ", "O     O", "O     O", "O     O", " OOOOO " }},
                {'P', new[] { "PPPPPP ", "P     P", "PPPPPP ", "P      ", "P      " }},
                {'Q', new[] { " QQQQQ ", "Q     Q", "Q     Q", "Q   Q Q", " QQQQ Q" }},
                {'R', new[] { "RRRRRR ", "R     R", "RRRRRR ", "R   R  ", "R     R" }},
                {'S', new[] { " SSSSS ", "S     S", " SSSSS ", "      S", " SSSSS " }},
                {'T', new[] { "TTTTTTT", "   T   ", "   T   ", "   T   ", "   T   " }},
                {'U', new[] { "U     U", "U     U", "U     U", "U     U", " UUUUU " }},
                {'V', new[] { "V     V", "V     V", "V      V", " V   V ", "  VVV  " }},
                {'W', new[] { "W     W", "W     W", "W  W  W", "W W W W", " WW WW " }},
                {'X', new[] { "X     X", " X   X ", "  X X  ", "   X   ", "X     X" }},
                {'Y', new[] { "Y     Y", " Y   Y ", "  Y Y  ", "   Y   ", "   Y   " }},
                {'Z', new[] { "ZZZZZZZ", "     Z ", "   ZZ  ", "  Z    ", "ZZZZZZZ" }},
                {' ', new[] { "       ", "       ", "       ", "       ", "       " }}
            };

            string fullText = welcomeText.ToUpper() + " " + username;

            ForegroundColor = ConsoleColor.Cyan;

            for (int line = 0; line < 5; line++)
            {
                foreach (char c in fullText)
                {
                    if (asciiArt.ContainsKey(c))
                        Write(asciiArt[c][line] + "  ");
                    else
                        Write("       ");
                }
                WriteLine();
            }

            ResetColor();
        }
    }
}
