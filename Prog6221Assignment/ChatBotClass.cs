using System;
using System.Collections.Generic;

namespace CybersecurityChatBot
{
    public class ChatbotEngine
    {
        private readonly Random rand = new Random();
        private readonly Dictionary<string, string[]> responses;

        public ChatbotEngine()
        {
            responses = new Dictionary<string, string[]>
            {
                { "purpose", new[]
                    {
                        "I am a Cybersecurity Awareness Bot designed to help you stay safe online.",
                        "My purpose is to educate users about online threats and best practices.",
                        "I help people understand how to protect themselves from cyber attacks."
                    }
                },
                { "how are you", new[]
                    {
                        "I'm doing great and ready to help you with cybersecurity tips!",
                        "I'm functioning at 100% security level! How can I assist you today?"
                    }
                },
                { "hello", new[]
                    {
                        "Hello! Great to see you. How can I help with your online safety today?",
                        "Hi there! 👋 Ready to learn some cybersecurity awareness?"
                    }
                },
                { "protect", new[]
                    {
                        "Use strong unique passwords, enable 2FA, and never click suspicious links.",
                        "Keep your software updated, use antivirus, and avoid public Wi-Fi for sensitive tasks."
                    }
                },
                { "phishing", new[]
                    {
                        "Phishing is when attackers trick you into giving sensitive information. Always check URLs!",
                        "Never click links in suspicious emails. Hover over links to see the real destination."
                    }
                },
                { "password", new[]
                    {
                        "Use passwords with at least 12 characters, mix of letters, numbers, and symbols.",
                        "Never reuse the same password across different websites."
                    }
                },
                { "cybersecurity", new[]
                    {
                        "Cybersecurity is protecting systems, networks, and data from digital attacks.",
                        "Good cybersecurity practices include strong passwords, updates, and awareness."
                    }
                },
                
            };
        }

        public void StartChat(UIHelper ui)
        {
            ui.WriteLine("\nType 'exit' or 'quit' anytime to end the conversation.\n", ConsoleColor.Yellow);

            while (true)
            {
                string input = ui.ReadInput("You: ");

                if (string.IsNullOrEmpty(input))
                {
                    ui.ShowInvalidInputMessage();
                    continue;
                }

                if (input.ToLower() == "exit" || input.ToLower() == "quit")
                {
                    ui.WriteLine("Chatbot: Goodbye! Stay safe online 🔐", ConsoleColor.Green);
                    break;
                }

                string response = GetResponse(input);
                ui.WriteChatbotResponse(response);
            }
        }

        private string GetResponse(string input)
        {
            string lowerInput = input.ToLower();

            foreach (var item in responses)
            {
                if (lowerInput.Contains(item.Key))
                {
                    return item.Value[rand.Next(item.Value.Length)];
                }
            }

            // Fallback responses
            string[] fallbacks =
            {
                "I'm not sure I understood that. Could you rephrase?",
                "I specialize in cybersecurity topics. Try asking about passwords, phishing, or online safety.",
                "Interesting! Can you ask me something about protecting yourself online?",
                "I didn't quite catch that. How can I help you with cybersecurity awareness today?"
            };

            return fallbacks[rand.Next(fallbacks.Length)];
        }
    }
}
