using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUni_Courses
{
    class SoftUniCourses
    {
        static void Main(string[] args)
        {
            List<string> programme = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine(); 

            while (command != "course start")
            {
                string[] reschedule = command.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (reschedule[0] == "Add")
                {
                    string lesson = reschedule[1];
                    if (programme.Contains(lesson) == false)
                    {
                        programme.Add(lesson);
                    }
                }
                else if (reschedule[0] == "Insert")
                {
                    string lesson = reschedule[1];
                    int index = int.Parse(reschedule[2]);
                    if (programme.Contains(lesson) == false && index >= 0 && index < programme.Count)
                    {
                        programme.Insert(index, lesson);
                    }
                }
                else if (reschedule[0] == "Remove")
                {
                    string lesson = reschedule[1];
                    if (programme.Contains(lesson))
                    {
                        programme.RemoveAll(i => i == lesson);
                        programme.RemoveAll(i => i == $"{lesson}-Exercise");
                    }
                }
                else if (reschedule[0] == "Swap")
                {
                    string lessonOne = reschedule[1];
                    string lessonTwo = reschedule[2];

                    if (programme.Contains(lessonOne) && programme.Contains(lessonTwo))
                    {
                        int lessonOneIndex = programme.IndexOf(lessonOne);
                        int lessonTwoIndex = programme.IndexOf(lessonTwo);
                        
                        programme[lessonOneIndex] = lessonTwo;

                        if (programme.Contains(lessonTwo + "-Exercise"))
                        {
                            programme.Insert(lessonOneIndex + 1, lessonTwo + "-Exercise");
                            programme.RemoveAt(lessonTwoIndex + 2);
                            programme[lessonTwoIndex+1] = lessonOne;
                        }
                        else
                        {
                            programme[lessonTwoIndex] = lessonOne;
                        }

                        if (programme.Contains(lessonOne +"-Exercise"))
                        {
                            if (lessonTwoIndex == programme.Count - 1)
                            {
                                programme.Add(lessonOne + "-Exercise");
                            }
                            else
                            {
                                programme.Insert(lessonTwoIndex + 1, lessonOne + "-Exercise");
                            }
                            programme.RemoveAt(lessonOneIndex + 1);
                        }
                    }
                }
                else if (reschedule[0] == "Exercise")
                {
                    string lesson = reschedule[1];
                    if (programme.Contains(lesson))
                    {
                        int lessonIndex = programme.IndexOf(lesson);
                        programme.Insert(lessonIndex + 1, lesson + "-Exercise");
                    }
                    else
                    {
                        programme.Add(lesson);
                        programme.Add(lesson + "-Exercise");
                    }
                }
                command = Console.ReadLine();
            }
            for (int i = 0; i < programme.Count; i++)
            {
                Console.WriteLine($"{i+1}.{programme[i]}");
            }
        }
    }
}
