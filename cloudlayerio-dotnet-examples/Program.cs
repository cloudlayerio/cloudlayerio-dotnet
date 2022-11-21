using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using cloudlayerio_dotnet;
using cloudlayerio_dotnet.requests;
using cloudlayerio_dotnet.responses;
using cloudlayerio_dotnet.types;

namespace cloudlayerio_dotnet_examples
{
    internal static class Program
    {
        private static CloudlayerioManager _manager;
        private static Dictionary<string, Func<Task>> _options;

        private static readonly string[] Websites =
        {
            "https://en.wikipedia.org/wiki/Hypericum_calycinum", //1
            "https://www.bing.com/", //2
            "https://www.msn.com/en-us", //3
            "https://reddit.com", //4
            "https://github.com", //5
            "https://www.bbc.com/", //6
            "https://microsoft.com", //7
            "https://mozilla.org", //8
            "https://wordpress.org" //9
        };

        private static async Task Main(string[] args)
        {
            Console.WriteLine(
                "This is an example application demonstrating the very basic capabilities of cloudlayer.io. Before proceeding, open your dashboard to observe the progress:");
            Console.WriteLine("https://app.cloudlayer.io/jobs");
            Console.WriteLine();


            var key = GetKey();
            _manager = new CloudlayerioManager(key);
            _options = new Dictionary<string, Func<Task>>
            {
                ["UrlToImage Single Website"] = GetGoogleImage,
                ["UrlToImage Batch 10 in Parallel (High Resolution, Autoscroll)"] =
                    () => Get10Websites(GetUrlToImageTasks()),
                ["UrlToPdf Single Website"] = GetGooglePdf,
                ["UrlToPdf Batch 10 in Parallel (High Resolution, Autoscroll)"] =
                    () => Get10Websites(GetUrlToPdfTasks()),
                ["DocxToPdf (test_data\\Example.docx -> examples_out\\DocxToPdf\\Example.pdf)"] =
                    GetFilesystemDocxToPdfExample,
                ["Exit"] = Exit
            };

            await GetSelection();
        }

        private static async Task GetFilesystemDocxToPdfExample()
        {
            DisplayBeginText("Example.docx");
            var rsp = await _manager.DocxToPdf(new DocxToPdf()
            {
                FilePath = Path.Combine(Environment.CurrentDirectory, "test_data", "Example.docx")
            });

            DisplayEndText($"The asset url is: {rsp.Response.AssetUrl}");
            DisplayEndText(
                "The response has been saved to your filesystem successfully! (Check the bin directory)");
            DisplayContinueText();
        }


        private static Task Exit()
        {
            Console.Clear();
            Console.WriteLine("Exiting application...");
            Environment.Exit(0);
            return Task.FromResult(true);
        }

        private static async Task GetSelection()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an option by entering the number:");
                Console.WriteLine("----------------------------------------");

                for (var i = 0; i <= _options.Count - 1; i++)
                    Console.WriteLine($"{i + 1}. {_options.Keys.ElementAt(i)}");

                Console.Write("Enter Selection: ");
                var selectionNumber = Convert.ToInt32(Console.ReadKey(false).KeyChar.ToString());

                Console.Clear();
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

        private static Task Get10Websites(Task[] tasks)
        {
            Console.WriteLine("Batch process started");
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Batch process completed");
            DisplayContinueText();

            return Task.FromResult(true);
        }

        private static Task[] GetUrlToImageTasks()
        {
            var tasks = new List<Task>();

            foreach (var url in Websites)
            {
                DisplayBeginText(url);
                tasks.Add(ProcessWebsite(url, ".png", "UrlToImage10", _manager.UrlToImage(new UrlToImage
                {
                    Url = url,
                    AutoScroll = true,
                    Timeout = 60000,
                    ViewPort = new ViewPort
                    {
                        Width = 1920,
                        Height = 1080,
                        DeviceScaleFactor = 2
                    },
                    Async = false
                })));
            }

            return tasks.ToArray();
        }

        private static Task[] GetUrlToPdfTasks()
        {
            var tasks = new List<Task>();
            foreach (var url in Websites)
            {
                DisplayBeginText(url);
                tasks.Add(ProcessWebsite(url, ".pdf", "UrlToPdf10", _manager.UrlToPdf(new UrlToPdf
                {
                    Url = url
                })));
            }

            return tasks.ToArray();
        }

        private static async Task ProcessWebsite<T>(string url, string ext, string dirName,
            Task<ReturnResponse<T>> task)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var rsp = await task;

            var fileName = new Uri(url).Host + ext;
            var filePath = Path.Combine("examples_out", dirName, fileName);

            stopwatch.Stop();

            DisplayEndText($"{(rsp.IsOk ? "Completed" : "Failed")}: ({stopwatch.Elapsed})");
            DisplayEndText($"The asset url is: {rsp.Response.AssetUrl}");

            if (!rsp.IsOk)
                Console.WriteLine("For failures, check the error.log in root of output folder.");
        }

        private static async Task GetGoogleImage()
        {
            const string url = "https://google.com";

            DisplayBeginText(url);
            var rsp = await _manager.UrlToImage(new UrlToImage
            {
                Url = url,
                Async = false
            });

            //await rsp.SaveToFilesystem(Path.Combine("examples_out", "UrlToImage", "google.png"));
            DisplayEndText($"The asset url is: {rsp.Response.AssetUrl}");
            DisplayContinueText();
        }

        private static async Task GetGooglePdf()
        {
            const string url = "https://google.com";

            DisplayBeginText(url);
            var rsp = await _manager.UrlToPdf(new UrlToPdf
            {
                Url = url,
                Async = false
            });
            
            DisplayEndText($"The asset url is: {rsp.Response.AssetUrl}");
            DisplayContinueText();
        }

        private static void DisplayContinueText()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        private static void DisplayEndText(string message)
        {
            Console.Write(
                message);
            Console.WriteLine();
        }

        private static void DisplayBeginText(string url)
        {
            Console.WriteLine($"{url}: Working, please wait...");
        }
    }
}