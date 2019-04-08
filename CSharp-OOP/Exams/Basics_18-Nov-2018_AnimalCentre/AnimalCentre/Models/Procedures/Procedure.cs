namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AnimalCentre.Models.Contracts;

    public abstract class Procedure : IProcedure
    {
        private IList<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        protected IList<IAnimal> ProcedureHistory
        {
            get => this.procedureHistory;
            set { this.procedureHistory = value; }
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            this.ValidateProcedureTime(animal, procedureTime);
            this.DecreaseAnimalProcedureTime(animal, procedureTime);
        }

        private void DecreaseAnimalProcedureTime(IAnimal animal, int procedureTime)
        {
            animal.ProcedureTime -= procedureTime;
        }

        private void ValidateProcedureTime(IAnimal animal, int procedureTime)
        {
            if(animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }

        public string History()
        {
            var historyInfo = new StringBuilder();

            foreach (var animal in this.ProcedureHistory)
            {
                historyInfo.AppendLine($"{this.GetType().Name}\n\t- {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return historyInfo.ToString().TrimEnd();
        }
    }
}
