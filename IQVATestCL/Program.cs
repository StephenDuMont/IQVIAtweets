using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

using IQVATest;

namespace IQVATestCL
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
            .WithParsed<Options>(opts => RunOptionsAndReturnExitCode(opts))
            .WithNotParsed<Options>((errs) => HandleParseError(errs));
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            foreach (Error e in errs)
            {
                Console.WriteLine(e.Tag.ToString());
            }

        }

        private static void RunOptionsAndReturnExitCode(Options opts)
        {
            if (opts.startDate > opts.endDate)
            {
                Console.WriteLine("Check Dates and try again, StartDate exceeds EndDate");
                return;
            }
            List<Tweet> tweets = TweetParser.GetFullRange(opts.startDate, opts.endDate);

            sendTweetsToConsole(tweets);
        }
        private static void sendTweetsToConsole(List<Tweet> tweets)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (Tweet t in tweets)
            {
                switch (Console.ForegroundColor)
                {
                    case ConsoleColor.Red:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case ConsoleColor.Blue:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case ConsoleColor.Green:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;

                }
                Console.WriteLine(String.Format("{0} - {1}", t.stamp.ToShortDateString(), t.text));
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}