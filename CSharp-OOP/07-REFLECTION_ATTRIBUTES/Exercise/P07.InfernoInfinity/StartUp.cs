using P07.InfernoInfinity.Core;
using P07.InfernoInfinity.Core.Factories;
using P07.InfernoInfinity.Data;

namespace P07.InfernoInfinity
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var weaponFactory = new WeaponFactory();
            var gemfactory = new GemFactory();
            var repository = new Repository();

            var engine = new Engine(weaponFactory, gemfactory, repository);
            engine.Run();
        }
    }
}
