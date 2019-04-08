namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class DentalCare : Procedure
    {
        private const int IncreaseHappinessPoints = 12;
        private const int IncreaseEnergyPoints = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.Happiness += IncreaseHappinessPoints;
            animal.Energy += IncreaseEnergyPoints;
            base.ProcedureHistory.Add(animal);
        }
    }
}
