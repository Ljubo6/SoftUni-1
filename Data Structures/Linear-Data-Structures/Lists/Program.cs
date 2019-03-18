public class Program
{
    public static void Main(string[] args)
    {
        ArrayList<int> list = new ArrayList<int>();

        for (int i = 0; i < 100; i++)
        {
            list.Add(i);
        }

        for (int i = 0; i < 50; i++)
        {
            list.RemoveAt(0);
        }
    }
}
