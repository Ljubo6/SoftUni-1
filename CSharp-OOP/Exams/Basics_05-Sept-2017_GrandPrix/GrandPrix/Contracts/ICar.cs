public interface ICar
{
    int Hp { get; }
    double FuelAmount { get; }
    Tyre Tyre { get; }
    void Refuel(double fuel);
}
