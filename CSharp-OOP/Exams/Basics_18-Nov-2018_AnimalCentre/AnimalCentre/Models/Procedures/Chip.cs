namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    using System;

    public class Chip : Procedure
    {
        private const int DecreaseHappinessPoints = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            base.DoService(animal, procedureTime);
            animal.IsChipped = true;
            animal.Happiness -= DecreaseHappinessPoints;

            base.ProcedureHistory.Add(animal);
        }
    }
}
