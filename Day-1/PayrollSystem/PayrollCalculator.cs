using System;

public class PayrollCalculator
{
    public double CalculateRegularPay(Employee employee)
    {
        double regularHours = Math.Min(employee.HoursWorked, 40);

        return regularHours * employee.HourlyRate;
    }

    public double CalculateOvertimePay(Employee employee)
    {
        if (employee.HoursWorked <= 40)
        {
            return 0;
        }

        double overtimeHours = employee.HoursWorked - 40;

        return overtimeHours * employee.HourlyRate * 1.5;
    }

    public double CalculateGrossSalary(Employee employee)
    {
        return CalculateRegularPay(employee) + CalculateOvertimePay(employee);
    }
}