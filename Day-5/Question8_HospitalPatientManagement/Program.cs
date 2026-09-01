using System;
using System.Collections.Generic;
using System.Linq;

namespace Question8_HospitalPatientManagement
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Condition { get; set; }
        public List<string> MedicalHistory { get; set; }

        public Patient(int id, string name, int age, string condition)
        {
            Id = id;
            Name = name;
            Age = age;
            Condition = condition;
            MedicalHistory = new List<string>();
        }
    }

    public class HospitalManager
    {
        private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
        private Queue<Patient> _appointmentQueue = new Queue<Patient>();

        public void RegisterPatient(int id, string name, int age, string condition)
        {
            if (!_patients.ContainsKey(id))
            {
                _patients[id] = new Patient(id, name, age, condition);
            }
        }

        public void ScheduleAppointment(int patientId)
        {
            if (_patients.TryGetValue(patientId, out var patient))
            {
                _appointmentQueue.Enqueue(patient);
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        public Patient? ProcessNextAppointment()
        {
            if (_appointmentQueue.Count > 0)
            {
                return _appointmentQueue.Dequeue();
            }
            return null;
        }

        public List<Patient> FindPatientsByCondition(string condition)
        {
            return _patients.Values
                .Where(p => string.Equals(p.Condition, condition, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalManager manager = new HospitalManager();

            manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
            manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");

            manager.ScheduleAppointment(1);
            manager.ScheduleAppointment(2);

            Patient? nextPatient = manager.ProcessNextAppointment();
            Console.WriteLine(nextPatient?.Name);

            List<Patient> diabeticPatients = manager.FindPatientsByCondition("Diabetes");
            Console.WriteLine(diabeticPatients.Count);
        }
    }
}
