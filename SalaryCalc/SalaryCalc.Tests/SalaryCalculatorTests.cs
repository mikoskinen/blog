using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalc.Tests
{
    [TestClass]
    public class SalaryCalculatorTests
    {
        [TestMethod]
        public void CanCalculateSalary()
        {
            const int baseSalary = 1500;
            const double salaryPerSecond = (double)baseSalary / 2678400;

            var result = SalaryCalculator.CalculateSalaryDataByMonthlySalary(baseSalary);

            Assert.AreEqual(result.PerMonth, baseSalary);
            Assert.AreEqual(result.PerYear, baseSalary * 12);

            Assert.AreEqual(result.PerSecond, salaryPerSecond);
            Assert.AreEqual(result.PerMinute, salaryPerSecond * 60);
            Assert.AreEqual(result.PerHour, salaryPerSecond * 60 * 60);
            Assert.AreEqual(result.PerDay, salaryPerSecond * 60 * 60 * 24);
            Assert.AreEqual(result.PerWeek, salaryPerSecond * 60 * 60 * 24 * 7);
        }
    }
}
