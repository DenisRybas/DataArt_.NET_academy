using System;
using System.IO;
using NUnit.Framework;
using ReportGenerator.ReportGenerators;

namespace ReportGenerator.Tests
{
    public class ReportGeneratorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WrongFilePathTest()
        {
            var reportGeneratorFromFile = new ReportGeneratorFromFile();
            Assert.Throws<FileNotFoundException>(() => reportGeneratorFromFile
                .TodaysOrdersReport("Test.txt"));
        }

        /// <summary>
        /// Email обязательно должен содержать "." после "@". Функциональность программы позволяет обойти это
        /// (строка 81 класса ReportGenerator)
        /// </summary>
        [Test]
        public void EmailWithoutDot()
        {
            var reportGenerator = new ReportGenerators.ReportGenerator();
            Assert.AreEqual(reportGenerator.TodaysOrdersReport(@"abby@voidcom 2021-03-28 10:00 P01 1"),
                @"Email, Price
abby@void.com, $12.00".Replace("\r\n", "\n"));
        }

        /// <summary>
        /// Происходит потеря точности из-за строки "(double) (totalCostInCents / 100)" в классе ReportGenerator
        /// (Строка 153).
        /// </summary>
        [Test]
        public void LossOfPrecision()
        {
            var reportGenerator = new ReportGenerators.ReportGenerator();
            var expected = "abby@void.com 2021-03-28 10:00 P43 1"; //цена в центах P43 = 199

            Assert.AreEqual(reportGenerator.TodaysOrdersReport(expected), @"Email, Price
abby@void.com, $1.99".Replace("\r\n", "\n"));
        }

        [Test]
        public void NotTodayPurchase()
        {
            var reportGenerator = new ReportGenerators.ReportGenerator();
            Assert.AreEqual(reportGenerator.TodaysOrdersReport(@"abby@void.com 2021-02-28 10:00 P01 1"),
                "Email, Price\n");
        }

        [Test]
        public void PurchaseFromFuture()
        {
            var reportGenerator = new ReportGenerators.ReportGenerator();
            Assert.AreEqual(reportGenerator.TodaysOrdersReport(@"abby@void.com 2021-05-28 10:00 P01 1"),
                "Email, Price\n");
        }

        [Test]
        public void TodaysPurchase()
        {
            var reportGenerator = new ReportGenerators.ReportGenerator();
            Assert.AreEqual(reportGenerator.TodaysOrdersReport(@"abby@void.com 2021-03-28 10:00 P01 1"),
                @"Email, Price
abby@void.com, $12.00".Replace("\r\n", "\n"));
        }

        [Test]
        public void NotExcitedProduct()
        {
            var reportGenerator = new ReportGenerators.ReportGenerator();
            Assert.Throws<NullReferenceException>(() =>
                reportGenerator.TodaysOrdersReport(@"abby@void.com 2021-03-28 10:00 A32 1"));
        }

        /// <summary>
        /// Если количество товара не указано явно, то значение количества принимается за 1
        /// </summary>
        [Test]
        public void QuantityOfProductNotEntered()
        {
            var reportGenerator = new ReportGenerators.ReportGenerator();
            Assert.AreEqual(reportGenerator.TodaysOrdersReport(@"abby@void.com 2021-03-28 10:00 P01"),
                @"Email, Price
abby@void.com, $12.00".Replace("\r\n", "\n"));
        }

        /// <summary>
        /// Если ввод не совсем правильный (упущен 1 пробел), то программа перестаёт работать.
        /// При использовании программы следует вводить данные строго по формату.
        /// </summary>
        [Test]
        public void ExcessSpaceEntered()
        {
            var reportGenerator = new ReportGenerators.ReportGenerator();
            Assert.AreEqual(reportGenerator.TodaysOrdersReport(@"abby@void.com  2021-03-28 10:00 P01 1"),
                @"Email, Price
abby@void.com, $12.00".Replace("\r\n", "\n"));
        }
    }
}