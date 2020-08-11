using System;

namespace AmazonCloudWatch
{
    class Program
    {

        static void Main(string[] args)
        {
            LogHelper.ILogger logger = new LogHelper.CloudWatchLogs();
            Console.WriteLine("Type message send to AWS :         ");
            var msg = Console.ReadLine();
            var result = logger.Log(msg);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
