using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using cloudlayerio_dotnet;
using cloudlayerio_dotnet.requests;

namespace cloudlayerio_dotnet_examples
{
    class Program
    {
        private static CloudlayerioManager _manager;
        private static Dictionary<string, Func<Task>> _options;

        static async Task Main(string[] args)
        {
            Console.WriteLine(
                "This is an example application demonstrating the very basic capabilities of cloudlayer.io");
            Console.WriteLine();


            var key = GetKey();
            _manager = new CloudlayerioManager(key);
            _options = new Dictionary<string, Func<Task>>
            {
                ["UrlToPdf (google.com) -> google.pdf"] = GetGooglePdf
            };

            await GetSelection();
        }

        private static async Task GetSelection()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an option by entering the number:");
                Console.WriteLine("----------------------------------------");

                for (var i = 0; i <= _options.Count - 1; i++)
                {
                    Console.WriteLine($"{i + 1}. {_options.Keys.ElementAt(i)}");
                }

                Console.Write("Enter Selection: ");
                var selectionNumber = Convert.ToInt32(Console.ReadKey(false).KeyChar.ToString());

                await _options.Values.ElementAt(selectionNumber - 1).Invoke();
            }
        }

        private static string GetKey()
        {
            while (true)
            {
                Console.WriteLine("Please paste in your key to continue:");
                var key = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(key) && key.Length == 35 && key.StartsWith("cl-")) return key;

                Console.WriteLine(
                    "Key is not correct format, should begin with 'cl-', and be 35 characters in length.");
            }
        }

        private static async Task GetGooglePdf()
        {
            Console.Clear();
            Console.WriteLine("Working, please wait...");
            var rsp = await _manager.UrlToImage(new UrlToImage
            {
                Url = "https://google.com"
            });

            await rsp.SaveToFilesystem("google.png");
            Console.Write(
                "The image google.png has been saved to your filesystem successfully! (Check the bin directory)");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}