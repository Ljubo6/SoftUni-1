using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.IO
{
    public class Reader : IReader
    {
        public IList<ICommand> ReadCommands()
        {
            var input = Console.ReadLine().Split();

            var commandString = input[0];
            var args = input.Skip(1).ToList();

            //var command = new Command

            return new List<ICommand>();
        }
    }
}
