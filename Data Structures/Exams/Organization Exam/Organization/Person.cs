public class Person
{
    public Person(string name, double salary)
    {
        this.Name = name;
        this.Salary = salary;
    }

    public string Name { get; set; }
    public double Salary { get; set; }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return (this.Name.GetHashCode() << 1) * 17;
    }
}
