namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class Play : Procedure
    {
        private const int IncreaseHappinessPoints = 12;
        private const int DecreaseEnergyPoints = 6;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.Happiness += IncreaseHappinessPoints;
            animal.Energy -= DecreaseEnergyPoints;
            base.ProcedureHistory.Add(animal);
        }
    }
}
