public class Relative
{
    public string Name { get; set; }
    public string DoB { get; set; }

    public Relative()
    {

    }

    public Relative(string name, string DoB)
    {
        this.Name = name;
        this.DoB = DoB;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.DoB}";
    }
}
