using System;

Patient patient = new Patient();

patient.Age = Validator.ReadAge();
patient.Weight = Validator.ReadWeight();
patient.Height = Validator.ReadHeight();
patient.Temperature = Validator.ReadTemperature();

double bmi = patient.Weight / (patient.Height * patient.Height);

bmi = Math.Round(bmi, 2);

Console.WriteLine();
Console.WriteLine("Patient Summary");
Console.WriteLine("------------------------");
Console.WriteLine($"Age: {patient.Age}");
Console.WriteLine($"Weight: {patient.Weight:F2} kg");
Console.WriteLine($"Height: {patient.Height:F2} m");
Console.WriteLine($"Temperature: {patient.Temperature:F2} °C");
Console.WriteLine($"BMI: {bmi:F2}");