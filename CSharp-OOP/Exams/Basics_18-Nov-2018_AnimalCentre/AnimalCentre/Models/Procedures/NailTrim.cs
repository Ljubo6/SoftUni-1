namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class NailTrim : Procedure
    {
        private const int DecreaseHappinessPoints = 7;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.Happiness -= DecreaseHappinessPoints;
            base.ProcedureHistory.Add(animal);
        }
    }
}
