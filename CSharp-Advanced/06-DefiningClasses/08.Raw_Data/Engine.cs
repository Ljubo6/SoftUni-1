public class Engine
{
    private int speed;
    private int power;

    public int Speed
    {
        get => this.speed;
        set
        {
            if (value >= 0)
            {
                this.speed = value;
            }
        }
    }

    public int Power
    {
        get => this.power;
        set
        {
            if (value >= 0)
            {
                this.power = value;
            }
        }
    }

    public Engine(int speed, int power)
    {
        this.Speed = speed;
        this.Power = power;
    }
}
