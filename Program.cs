using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyAuth_Hash
{
    class Program
    {
		static void Main(string[] args)
		{
			Console.Title = "KeyAuth.com";
			string argument;
			keyauthlogo();
			Console.CursorLeft = 20;

			argument = Console.ReadLine();

			if (argument == "")
            {
				Environment.Exit(0);
            }
			else
            {
				
            }

			var checksum = GetMD5Checksum(argument);

			Console.Clear();
			Console.Title = "KeyAuth.com";
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("             ██   ██ ███████ ██    ██  █████  ██    ██ ████████ ██   ██     ██████  ██████  ███    ███ ");
			Console.WriteLine("             ██  ██  ██       ██  ██  ██   ██ ██    ██    ██    ██   ██    ██      ██    ██ ████  ████ ");
			Console.WriteLine("             █████   █████     ████   ███████ ██    ██    ██    ███████    ██      ██    ██ ██ ████ ██ ");
			Console.WriteLine("             ██  ██  ██         ██    ██   ██ ██    ██    ██    ██   ██    ██      ██    ██ ██  ██  ██ ");
			Console.WriteLine("             ██   ██ ███████    ██    ██   ██  ██████     ██    ██   ██ ██  ██████  ██████  ██      ██ ");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("             -----------------------------------------------------------------------------------------");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("             |                           " + checksum + "                            |");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("             -------------------------------------HASH CHECKER----------------------------------------");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.ReadLine();
		}

		public static void keyauthlogo()
        {
			Console.WriteLine("");
			Console.WriteLine("             ---------------------------- PLEASE DRAG AND DROP FILE HERE------------------------------");
			Console.WriteLine("             ██   ██ ███████ ██    ██  █████  ██    ██ ████████ ██   ██     ██████  ██████  ███    ███ ");
			Console.WriteLine("             ██  ██  ██       ██  ██  ██   ██ ██    ██    ██    ██   ██    ██      ██    ██ ████  ████ ");
			Console.WriteLine("             █████   █████     ████   ███████ ██    ██    ██    ███████    ██      ██    ██ ██ ████ ██ ");
			Console.WriteLine("             ██  ██  ██         ██    ██   ██ ██    ██    ██    ██   ██    ██      ██    ██ ██  ██  ██ ");
			Console.WriteLine("             ██   ██ ███████    ██    ██   ██  ██████     ██    ██   ██ ██  ██████  ██████  ██      ██ ");
			Console.WriteLine("             --------------------------------------KeyAuth.com----------------------------------------");
			Console.WriteLine("");
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