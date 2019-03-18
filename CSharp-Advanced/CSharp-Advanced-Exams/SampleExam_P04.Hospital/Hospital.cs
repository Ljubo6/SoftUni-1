using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleExam_P01.Hospital
{
    public class Hospital
    {
        public static void Main()
        {
            var hospital = new Dictionary<string, Department>();
            var doctors = new List<Doctor>();
            
            FillHospitalDB(hospital, doctors);

            // executing commands from console
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArray = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commandArray.Length == 1)
                {
                    if (hospital.ContainsKey(commandArray[0]))
                    {
                        var departmentToPrint = hospital[commandArray[0]];

                        foreach (var room in departmentToPrint.Rooms)
                        {
                            foreach (var patient in room.Patients)
                            {
                                Console.WriteLine(patient.Name);
                            }
                        }
                    }
                }

                else if (commandArray.Length == 2)
                {
                    string firstName = commandArray[0];
                    string lastName = commandArray[1];

                    var doctorToPrint = doctors.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

                    if (doctorToPrint != null)
                    {
                        List<Patient> doctorsPatients = doctorToPrint.Patients.OrderBy(x => x.Name).ToList();

                        foreach (var patient in doctorsPatients)
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                    else
                    {
                        string department = commandArray[0];
                        int roomNumber = int.Parse(commandArray[1]);

                        var currentRoom = hospital[department].Rooms.FirstOrDefault(x => x.Number == roomNumber);

                        if (currentRoom != null)
                        {
                            foreach (var patient in currentRoom.Patients.OrderBy(x => x.Name))
                            {
                                Console.WriteLine(patient.Name);
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
        }

        private static void FillHospitalDB(Dictionary<string, Department> hospital, List<Doctor> doctors)
        {
            string[] input = Console.ReadLine().Split();
            while (input[0] != "Output")
            {
                string department = input[0];
                string doctorFistName = input[1];
                string doctorLastName = input[2];
                string patientName = input[3];

                var newPatient = new Patient(patientName);
                var currentDoctor = doctors.FirstOrDefault(x => x.FirstName == doctorFistName && x.LastName == doctorLastName);

                // adding patient to department
                if (!hospital.ContainsKey(department))
                {
                    hospital.Add(department, new Department());
                    hospital[department].Add(newPatient);
                }
                else
                {
                    if (hospital[department].HasFreeRooms())
                    {
                        hospital[department].Add(newPatient);
                    }
                }

                //adding patient to doctor's list
                if (currentDoctor == null)
                {
                    doctors.Add(new Doctor(doctorFistName, doctorLastName));
                    currentDoctor = doctors.FirstOrDefault(x => x.FirstName == doctorFistName && x.LastName == doctorLastName);
                }

                currentDoctor.Patients.Add(newPatient);

                input = Console.ReadLine().Split();
            }
        }
    }

    public class Department
    {
        private const int roomCount = 20;
        private const int roomCapacity = 3;
        private const int bedCapacity = roomCapacity * roomCount;

        public Department()
        {
            this.Rooms = new List<Room>();
        }

        public List<Room> Rooms { get; set; }

        public bool HasFreeRooms()
        {
            return bedCapacity - this.Rooms.Sum(x => x.Patients.Count) > 0;
        }

        public void Add(Patient patient)
        {
            bool roomFound = false;

            foreach (var room in this.Rooms)
            {
                if (room.Patients.Count == roomCapacity)
                {
                    continue;
                }
                else
                {
                    room.Patients.Add(patient);
                    roomFound = true;
                }
            }

            if (roomFound == false)
            {
                var newRoom = new Room(this.Rooms.Count + 1);
                newRoom.Patients.Add(patient);
                this.Rooms.Add(newRoom);
            }
        }
    }

    public class Room
    {
        public Room(int number)
        {
            this.Number = number;
            this.Patients = new List<Patient>();
        }

        public int Number { get; set; }
        public List<Patient> Patients { get; set; }
    }

    public class Patient
    {
        public Patient(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    public class Doctor
    {
        public Doctor(string firstName, string LastName)
        {
            this.Patients = new List<Patient>();
            this.FirstName = firstName;
            this.LastName = LastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
