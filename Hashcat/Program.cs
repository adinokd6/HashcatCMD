using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Hashcat
{
    class Program
    {
        public static string inputHashCat;

        public static string completeCommand;

        public static string outputHashCat;

        static void Main(string[] args)
        {
            inputHashCat = Console.ReadLine();

            LaunchCommandLineAppAsync(inputHashCat);
        }

        static async Task LaunchCommandLineAppAsync(string input)
        {

            // For the example
            const string ex1 = "D:\\Projects\\Hashcat\\hsc\\";
            string filename = Path.Combine(ex1, "hashcat.exe");

            var proc = new ProcessStartInfo();
            proc.WorkingDirectory="D:\\Projects\\Hashcat\\hsc\\";
            proc.FileName = filename;
            proc.Arguments = input;

            Process hashCat = Process.Start(proc);


            try
            {

                StringBuilder tmpOutput = new StringBuilder();

                while (!hashCat.HasExited)
                {
                    tmpOutput.Append(hashCat.StandardOutput.ReadToEnd());
                }

                outputHashCat = tmpOutput.ToString();

                await File.WriteAllTextAsync("D:\\Writetext.txt", outputHashCat);
            }
            catch
            {
                // Log error.
            }

        }
    }
}
