using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Vapour_Obfuscator_Cleaner
{
    internal class ConsoleLogger
    {
        public static void LogError(string message)
        {
            Console.Write("  ");
            Console.BackgroundColor = Color.FromArgb(239, 83, 80);
            Console.Write(" ERROR ", Color.FromArgb(0, 0, 0));
            Console.ResetColor();
            Console.Write($"   {message}\n");
        }

        public static void LogInfo(string message)
        {
            Console.Write("  ");
            Console.BackgroundColor = Color.FromArgb(168, 132, 205);
            Console.Write(" INFO ", Color.FromArgb(0, 0, 0));
            Console.ResetColor();
            Console.Write($"    {message}\n");
        }

        public static void LogSuccess(string message)
        {
            Console.Write("  ");
            Console.BackgroundColor = Color.FromArgb(195, 255, 120);
            Console.Write(" SUCCESS ", Color.FromArgb(0, 0, 0));
            Console.ResetColor();
            Console.Write($" {message}\n");
        }

        public static void LogWarn(string message)
        {
            Console.Write("  ");
            Console.BackgroundColor = Color.FromArgb(255, 126, 70);
            Console.Write(" WARN ", Color.FromArgb(0, 0, 0));
            Console.ResetColor();
            Console.Write($"    {message}\n");
        }
    }
}
