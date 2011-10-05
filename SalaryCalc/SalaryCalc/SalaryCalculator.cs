using System;

namespace SalaryCalc
{
    public class SalaryCalculator
    {
        public static SalaryData CalculateSalaryDataByMonthlySalary(double yourMonthlySalary)
        {
            var result = new SalaryData { PerMonth = yourMonthlySalary };

            var secondsInMonth = TimeSpan.FromDays(31).TotalSeconds;

            result.PerSecond = yourMonthlySalary / secondsInMonth;
            result.PerMinute = result.PerSecond * 60;
            result.PerHour = result.PerMinute * 60;
            result.PerDay = result.PerHour * 24;
            result.PerWeek = result.PerDay * 7;
            result.PerYear = result.PerMonth * 12;

            return result;
        }
    }

    public class SalaryData
    {
        public double PerSecond { get; set; }
        public double PerMinute { get; set; }
        public double PerHour { get; set; }
        public double PerDay { get; set; }
        public double PerWeek { get; set; }
        public double PerMonth { get; set; }
        public double PerYear { get; set; }
    }
}
