using System;

Console.Write("Enter Employee Name: ");
string name = Console.ReadLine();

Console.Write("Enter Hours Worked: ");
string hoursInput = Console.ReadLine();

double hours;

if (!double.TryParse(hoursInput, out hours))
{
    Console.WriteLine("Invalid Hours");
    return;
}

if (hours < 0)
{
    Console.WriteLine("Hours cannot be negative");
    return;
}

if (hours > 300)
{
    Console.WriteLine("Hours value is too high");
    return;
}

Console.Write("Enter Hourly Rate: ");
string rateInput = Console.ReadLine();

double rate;

if (!double.TryParse(rateInput, out rate))
{
    Console.WriteLine("Invalid Hourly Rate");
    return;
}

if (rate <= 0)
{
    Console.WriteLine("Hourly Rate must be greater than zero");
    return;
}

Employee employee = new Employee
{
    Name = name,
    HoursWorked = hours,
    HourlyRate = rate
};

PayrollCalculator payroll = new PayrollCalculator();

double regularPay = payroll.CalculateRegularPay(employee);
double overtimePay = payroll.CalculateOvertimePay(employee);
double grossSalary = payroll.CalculateGrossSalary(employee);

Console.WriteLine();
Console.WriteLine($"Employee: {employee.Name}");
Console.WriteLine($"Regular Pay: {Math.Round(regularPay, 2):F2}");
Console.WriteLine($"Overtime Pay: {Math.Round(overtimePay, 2):F2}");
Console.WriteLine($"Gross Salary: {Math.Round(grossSalary, 2):F2}");