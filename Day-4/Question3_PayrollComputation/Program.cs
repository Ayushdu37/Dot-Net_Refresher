using System;
using System.Collections.Generic;

namespace Question3_PayrollComputation
{
    public abstract class Employee
    {
        public abstract decimal CalculatePay();
    }

    public class HourlyEmployee : Employee
    {
        private decimal rate;
        private decimal hours;

        public HourlyEmployee(decimal rate, decimal hours)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public override decimal CalculatePay()
        {
            return rate * hours;
        }
    }

    public class SalariedEmployee : Employee
    {
        private decimal monthlySalary;

        public SalariedEmployee(decimal monthlySalary)
        {
            this.monthlySalary = monthlySalary;
        }

        public override decimal CalculatePay()
        {
            return monthlySalary;
        }
    }

    public class CommissionEmployee : Employee
    {
        private decimal commission;
        private decimal baseSalary;

        public CommissionEmployee(decimal commission, decimal baseSalary)
        {
            this.commission = commission;
            this.baseSalary = baseSalary;
        }

        public override decimal CalculatePay()
        {
            return baseSalary + commission;
        }
    }

    internal class Program
    {
        static decimal ComputeTotalPayroll(string[] employees)
        {
            List<Employee> employeeList = new List<Employee>();

            foreach (string entry in employees)
            {
                if (string.IsNullOrWhiteSpace(entry))
                {
                    continue;
                }

                string[] parts = entry.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0)
                {
                    continue;
                }

                string type = parts[0].ToUpper();

                if (type == "H" && parts.Length == 3)
                {
                    decimal rate = Convert.ToDecimal(parts[1]);
                    decimal hours = Convert.ToDecimal(parts[2]);
                    employeeList.Add(new HourlyEmployee(rate, hours));
                }
                else if (type == "S" && parts.Length == 2)
                {
                    decimal salary = Convert.ToDecimal(parts[1]);
                    employeeList.Add(new SalariedEmployee(salary));
                }
                else if (type == "C" && parts.Length == 3)
                {
                    decimal commission = Convert.ToDecimal(parts[1]);
                    decimal baseSalary = Convert.ToDecimal(parts[2]);
                    employeeList.Add(new CommissionEmployee(commission, baseSalary));
                }
            }

            decimal total = 0m;
            foreach (Employee emp in employeeList)
            {
                total += emp.CalculatePay();
            }

            return Math.Round(total, 2, MidpointRounding.AwayFromZero);
        }

        static void Main(string[] args)
        {
            string[] employees = {
                "H 25.5 40",
                "S 5000",
                "C 1200 3000"
            };

            decimal total = ComputeTotalPayroll(employees);
            Console.WriteLine("Total Payroll: " + total.ToString("F2"));
        }
    }
}
