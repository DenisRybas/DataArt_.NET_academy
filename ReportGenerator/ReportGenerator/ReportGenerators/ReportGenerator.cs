using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ReportGenerator.ReportGenerators
{
    public class ReportGenerator
    {
        public string TodaysOrdersReport(string ordersStr)
        {
            var orders = ReadOrders(ordersStr)
                .Where(o => o.DateTime.Date == DateTime.Now.Date);

            var reportLines = CalculateTotalCostByCustomer(orders);

            return ReportToStr(reportLines);
        }

        protected IReadOnlyList<Order> ReadOrders(string ordersStr)
        {
            // Format: 
            // 
            // email1 yyyy-mm-dd hh:mm 
            // product-code1
            // product-code2 qty
            // email2 yyyy-mm-dd hh:mm 
            // product-code3
            // ...

            using var stream = new StringReader(ordersStr);

            var orders = new List<Order>();
            Order currentOrder = null;

            var lineCounter = 1;
            while (true)
            {
                var line = stream.ReadLine();
                lineCounter++;

                if (line == null)
                {
                    break;
                }

                var words = line.Split(' ');
                if (3 <= words.Length && words.Length <= 5)
                {
                    if (!TryParseOrder(words, out var order))
                    {
                        Console.WriteLine("Error in line " + lineCounter);
                        orders.Add(currentOrder);
                        return orders; 
                    }

                    if (currentOrder != null)
                    {
                        orders.Add(currentOrder);
                    }

                    currentOrder = order;
                }
                else if (words.Length == 2 || words.Length == 1)
                {
                    if (!TryParseOrderItem(words, out var item))
                    {
                        Console.WriteLine("Error in line " + lineCounter);
                        orders.Add(currentOrder);
                        return orders;
                    }

                    currentOrder = currentOrder?.AppendItem(item);
                }
            }

            orders.Add(currentOrder);

            return orders;
        }

        protected bool TryParseOrder(string[] words, out Order order)
        {
            var email = words[0];
            if (!email.Contains('@')) //TODO: Проверка на точку
            {
                order = null;
                return false;
            }

            if (!TryParseDateTime(words[1] + " " + words[2], "yyyy-MM-dd HH:mm", out var dateTime))
            {
                order = null;
                return false;
            }

            var items = Array.Empty<OrderItem>();
            if (words.Length > 3)
            {
                if (!TryParseOrderItem(words.Skip(3).ToArray(), out var item))
                {
                    order = null;
                    return false;
                }

                items = new[] {item};
            }

            order = new Order(email, dateTime, items);
            return true;
        }

        protected bool TryParseOrderItem(string[] words, out OrderItem item)
        {
            var productCode = words[0];

            if (!int.TryParse(ElementAtOrDefault(words, at: 1, defaultsTo: "1"), out var quantity))
            {
                item = null;
                return false;
            }

            if (quantity <= 0)
            {
                item = null;
                return false;
            }

            item = new OrderItem(productCode, quantity);
            return true;
        }

        protected bool TryParseDateTime(string dateTimeText, string format, out DateTime parsed)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var style = DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces;
            return DateTime.TryParseExact(dateTimeText, format, culture, style, out parsed);
        }

        protected T ElementAtOrDefault<T>(T[] array, int at, T defaultsTo)
        {
            return at < array.Length ? array[at] : defaultsTo;
        }

        protected IEnumerable<(string email, double totalCost)> CalculateTotalCostByCustomer(IEnumerable<Order> orders)
        {
            return orders
                .GroupBy(o => o.Email, StringComparer.CurrentCultureIgnoreCase)
                .OrderBy(g => g.Key, StringComparer.CurrentCultureIgnoreCase)
                .Select(orderGroup =>
                {
                    var totalCostInCents = orderGroup
                        .SelectMany(o => o.Items)
                        .Select(i => i.Quantity * ProductCatalog.FindProductByCode(i.ProductCode).PriceInCents)
                        .Sum();

                    return (orderGroup.Key, (double) (totalCostInCents / 100));
                });
        }

        protected string ReportToStr(IEnumerable<(string email, double totalCost)> reportLines)
        {
            var sb = new StringBuilder("Email, Price\n");
            foreach (var reportLine in reportLines)
            {
                sb.Append(
                    $"{reportLine.email}, ${reportLine.totalCost.ToString("F2", CultureInfo.InvariantCulture)}");
                sb.Append(reportLine == reportLines.Last() ? "" : "\n");
            }

            return sb.ToString();
        }
    }
}