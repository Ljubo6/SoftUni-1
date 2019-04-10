using System;

namespace P01.EventImplementation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var handler = new Handler();
            var dispatcher = new Dispatcher();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            while (true)
            {
                string name = Console.ReadLine();

                if(name == "End")
                {
                    return;
                }

                dispatcher.Name = name;
            }
        }
    }
}
