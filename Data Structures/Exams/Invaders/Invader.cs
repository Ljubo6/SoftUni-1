using System;

public class Invader : IInvader
{
    public Invader(int damage, int distance)
    {
        this.Damage = damage;
        this.Distance = distance;
    }
    
    public int Damage { get; set; }
    public int Distance { get; set; }

    public int CompareTo(IInvader other)
    {
        int distanceCompare = this.Distance.CompareTo(other.Distance);
        int damageCompare = other.Damage.CompareTo(this.Damage);

        return distanceCompare == 0 ? damageCompare : distanceCompare;
    }
}
