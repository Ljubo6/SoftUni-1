using System;
using System.Collections.Generic;
using System.Text;

class Kittens : Cat
{
    private const string gender = "Female";

    public Kittens(string name, int age)
        : base(name, age, gender)
    {

    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}
