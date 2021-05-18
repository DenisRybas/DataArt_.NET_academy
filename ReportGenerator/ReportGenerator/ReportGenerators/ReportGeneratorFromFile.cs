using System;
using System.IO;
using System.Linq;

namespace ReportGenerator.ReportGenerators
{
    public class ReportGeneratorFromFile : ReportGenerator
    {
        public new string TodaysOrdersReport(string pathToFile)
        {
            var ordersStr = File.ReadAllText(pathToFile);

            var orders = ReadOrders(ordersStr)
                .Where(o => o.DateTime.Date == DateTime.Now.Date);

            var reportLines = CalculateTotalCostByCustomer(orders);

            return ReportToStr(reportLines);
        }
    }
}