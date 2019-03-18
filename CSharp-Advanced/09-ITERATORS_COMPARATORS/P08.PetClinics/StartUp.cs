using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.PetClinics
{
    public class StartUp
    {
        public static void Main()
        {
            List<Pet> allPets = new List<Pet>();
            List<Clinic> allClinics = new List<Clinic>();

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                try
                {
                    switch (command)
                    {
                        case "Create":
                            if (input[1].ToLower() == "pet")
                            {
                                var pet = new Pet(input[2], int.Parse(input[3]), input[4]);
                                allPets.Add(pet);
                            }
                            else if (input[1].ToLower() == "clinic")
                            {
                                var clinic = new Clinic(input[2], int.Parse(input[3]));
                                allClinics.Add(clinic);
                            }
                            break;

                        case "Add":
                            var petToAdd = allPets.FirstOrDefault(p => p.Name == input[1]);
                            var clinicAddTo = allClinics.FirstOrDefault(c => c.Name == input[2]);

                            if (petToAdd == null || clinicAddTo == null)
                            {
                                throw new ArgumentException("Invalid Operation!");
                            }
                            Console.WriteLine(clinicAddTo.Add(petToAdd));
                            break;

                        case "Release":
                            var clinicToRelease = allClinics.FirstOrDefault(c => c.Name == input[1]);
                            if (clinicToRelease == null)
                            {
                                throw new ArgumentException("Invalid Operation!");
                            }
                            Console.WriteLine(clinicToRelease.Release());
                            break;

                        case "HasEmptyRooms":
                            var clinicToCheckEmptyRooms = allClinics.FirstOrDefault(c => c.Name == input[1]);
                            if (clinicToCheckEmptyRooms == null)
                            {
                                Console.WriteLine("False");
                                break;
                            }
                            Console.WriteLine(clinicToCheckEmptyRooms.HasEmptyRooms());
                            break;
                        case "Print":
                            var clinicToPrintInfoAbout = allClinics.FirstOrDefault(c => c.Name == input[1]);
                            if (input.Length == 2)
                            {
                                foreach (var room in clinicToPrintInfoAbout)
                                {
                                    if (room == null)
                                    {
                                        Console.WriteLine("Room empty");
                                    }
                                    else
                                    {
                                        Console.WriteLine(room);
                                    }
                                }
                            }
                            else if (input.Length == 3)
                            {
                                int roomNumber = int.Parse(input[2]);
                                Console.WriteLine(clinicToPrintInfoAbout.PrintRoomContent(roomNumber));
                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
