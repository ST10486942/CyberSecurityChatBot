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
            try
            {
                var ui = new UIHelper();
                var audio = new AudioPlayer();
                var chatbot = new ChatbotEngine();
                var ascii = new AsciiArtGenerator();

                ui.ClearScreen();

                // Display Cybersecurity Bot Logo
                ui.DisplayBotLogo();

                // Play voice greeting
                audio.PlayGreeting();

                // Get user's name with validation
                string username = ui.GetUserName();

                // Show big ASCII Welcome + Name
                ascii.DisplayWelcomeWithNameInAscii("Welcome", username);

                ui.ShowMainHeader();

                // Start chatting
                chatbot.StartChat(ui);

                Console.WriteLine("\nThank you for using the Cybersecurity Awareness Bot. Stay safe online! 🔒");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}