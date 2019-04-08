namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class Vaccinate : Procedure
    {
        private const int DecreaseEnergyPoints = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.Energy -= DecreaseEnergyPoints;
            animal.IsVaccinated = true;
            base.ProcedureHistory.Add(animal);
        }
    }
}
