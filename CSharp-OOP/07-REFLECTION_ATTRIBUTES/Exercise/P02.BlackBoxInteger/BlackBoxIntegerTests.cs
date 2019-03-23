namespace P02.BlackBoxInteger
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var classType = typeof(BlackBoxInteger);

            var classConstructor = classType
                                    .GetConstructors(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                                    .FirstOrDefault();

            var classInstance = classConstructor.Invoke(new object[] { 0 });

            var classField = classInstance
                                .GetType()
                                .GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                                .FirstOrDefault();


            while (true)
            {
                var input = Console.ReadLine().Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                var methodCalled = input[0];

                if (methodCalled == "END")
                {
                    return;
                }

                var inputValue = int.Parse(input[1]);
                var methodToInvoke = GetMethod(classInstance, methodCalled);

                if(methodToInvoke != null)
                {
                    methodToInvoke.Invoke(classInstance, new object[] { inputValue });
                    Console.WriteLine(classField.GetValue(classInstance));
                }
            }
        }

        private static MethodInfo GetMethod(object classInstance, string methodCalled)
        {
            return classInstance
                            .GetType()
                            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                            .FirstOrDefault(x => x.Name == methodCalled);
        }
    }
}
