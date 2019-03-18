public class Cargo
{
    private string type;
    private int weight;

    public string Type
    {
        get => this.type;
        set
        {
            if (value != null)
            {
                this.type = value;
            }
        }
    }

    public int Weight
    {
        get => this.weight;
        set
        {
            if (value >= 0)
            {
                this.weight = value;
            }
        }
    }

    public Cargo(string type, int weight)
    {
        this.Type = type;
        this.Weight = weight;
    }
}
