using System;

public class StartUp
{
    public static void Main()
    {
        var student = Console.ReadLine().Split();
        var worker = Console.ReadLine().Split();

        if (student.Length > 2 && worker.Length > 3)
        {
            try
            {
                var newStudent = new Student(student[0], student[1], student[2]);
                var newWorker = new Worker(worker[0], worker[1], decimal.Parse(worker[2]), int.Parse(worker[3]));

                Console.WriteLine(newStudent);
                Console.WriteLine();
                Console.WriteLine(newWorker);
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
