using SIS.MvcFramework;

namespace Torshia.App
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.Start(new Startup());
        }
    }
}
