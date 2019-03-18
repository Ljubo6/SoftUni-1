using System.Linq;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;

    public string Model
    {
        get => this.model;
        set
        {
            if (value != null)
            {
                this.model = value;
            }
        }
    }

    public Engine Engine { get => this.engine; }
    public Cargo Cargo { get => this.cargo; }


    public Tire[] Tires
    {
        get => this.tires;
    }

    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        this.Model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }

    public bool hasTireWithValidPressure()
    {
        return this.tires.Any(t => t.Pressure < 1);
    }

    public bool hasEngineWithValidPower()
    {
        return this.engine.Power > 250;
    }   
}
