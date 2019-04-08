namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class Fitness : Procedure
    {
        private const int DecreaseHappinessPoints = 3;
        private const int IncreaseEnergyPoints = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.Happiness -= DecreaseHappinessPoints;
            animal.Energy += IncreaseEnergyPoints;
            base.ProcedureHistory.Add(animal);
        }
    }
}
