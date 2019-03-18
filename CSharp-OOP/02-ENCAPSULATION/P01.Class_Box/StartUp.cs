using System;

public class StartUp
{
    public static void Main()
    {
        try
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            Box newBox = new Box(l, w, h);

            Console.WriteLine($"Surface Area - {newBox.GetSurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {newBox.GetLateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {newBox.GetVolume():f2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
