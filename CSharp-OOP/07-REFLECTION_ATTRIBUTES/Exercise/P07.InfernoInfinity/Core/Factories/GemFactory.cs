using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;
using System;
using System.Linq;
using System.Reflection;

namespace P07.InfernoInfinity.Core.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem Create(string[] data)
        {
            ClarityLevel clarityLevel = Enum.Parse<ClarityLevel>(data[0]);
            var gemType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == data[1]);
            var instance = (IGem)Activator.CreateInstance(gemType, clarityLevel);
            return instance;
        }
    }
}
