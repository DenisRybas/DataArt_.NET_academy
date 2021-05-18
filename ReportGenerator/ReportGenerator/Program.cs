using System;
using ReportGenerator.ReportGenerators;

namespace ReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var reportGenFromFile = new ReportGeneratorFromFile();
            Console.WriteLine(reportGenFromFile.TodaysOrdersReport("orders-sample.txt"));
            
             var reportGenerator = new ReportGenerators.ReportGenerator();
             Console.WriteLine(reportGenerator.TodaysOrdersReport(@"abby@void.com 2021-03-28 10:00
P01 1
bobby@void.com 2021-03-28 13:39
P02b 2
P01 
charley@void.com 2021-03-55 13:39
P01 1
P42 5"));
         }
    }
}
