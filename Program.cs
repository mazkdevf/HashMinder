using System;
using System.IO;
using System.Windows.Forms;

namespace KeyAuth_Hash
{
    internal class Program
    {
        [STAThreadAttribute]
        private static void Main(string[] args)
        {
            Console.Title = "KeyAuth.win";
            keyauthlogo();
            Console.CursorLeft = 20;

            string filepath;

            if (args.Length != 1)
            {
                Console.Write("Filepath (Drag and Drop supported): ");
                filepath = Console.ReadLine();
            }
            else
            {
                filepath = args[0];
            }

            filepath = filepath.Replace("\"", String.Empty);

            if (!File.Exists(filepath))
            {
                Console.Clear();
                Console.WriteLine("Invalid File or Filepath Provided. ( " + filepath + " )");
                Console.ReadLine();
                Environment.Exit(2);
            }

            var md5hash = GetMD5Checksum(filepath);
            Clipboard.SetText(md5hash);

            Console.Clear();
            keyauthlogo();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("             |                           " + md5hash + "                            |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                                (Copied to Clipboard)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("             ------------------------------------------MD5-Hash--------------------------------------");
            Console.ResetColor();

            Console.ReadLine();
        }

        public static void keyauthlogo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("             -----------------------------------------------------------------------------------------");
            Console.WriteLine("             ██   ██ ███████ ██    ██  █████  ██    ██ ████████ ██   ██     ██████  ██████  ███    ███ ");
            Console.WriteLine("             ██  ██  ██       ██  ██  ██   ██ ██    ██    ██    ██   ██    ██      ██    ██ ████  ████ ");
            Console.WriteLine("             █████   █████     ████   ███████ ██    ██    ██    ███████    ██      ██    ██ ██ ████ ██ ");
            Console.WriteLine("             ██  ██  ██         ██    ██   ██ ██    ██    ██    ██   ██    ██      ██    ██ ██  ██  ██ ");
            Console.WriteLine("             ██   ██ ███████    ██    ██   ██  ██████     ██    ██   ██ ██  ██████  ██████  ██      ██ ");
            Console.WriteLine("             -----------------------------------------KeyAuth.win-------------------------------------");
            Console.WriteLine();
            Console.ResetColor();
        }

        public static string GetMD5Checksum(string filename)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "");
                }
            }
        }
    }
}