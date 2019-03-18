public class Tire
{
    private int age;
    private double pressure;

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value >= 0)
            {
                this.age = value;
            }
        }
    }

    public double Pressure
    {
        get
        {
            return this.pressure;
        }
        set
        {
            if (value > 0)
            {
                this.pressure = value;
            }
        }
    }

    public Tire(int age, double pressure)
    {
        this.Age = age;
        this.Pressure = pressure;
    }

}
