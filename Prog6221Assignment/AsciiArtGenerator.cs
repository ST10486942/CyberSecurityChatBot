using System;
using System.Collections.Generic;
using static System.Console;

namespace CybersecurityChatBot
{
    public class AsciiArtGenerator
    {
        // Show "Welcome" + username in big ASCII art
        public void DisplayWelcomeWithNameInAscii(string welcomeText, string username)
        {
            // Dictionary that stores ASCII art pattern for each character
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

            string fullText = welcomeText.ToUpper() + " " + username.ToUpper();

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

        // Simple centered text version
        public void DisplayWelcomeWithName(string username)
        {
            string message = $"Welcome, {username.ToUpper()}!";
            int padding = (Console.WindowWidth - message.Length) / 2;

            ForegroundColor = ConsoleColor.Green;
            WriteLine(new string(' ', Math.Max(0, padding)) + message);
            ResetColor();
        }
    }
}
