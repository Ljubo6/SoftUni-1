using System.Collections.Generic;

namespace Torshia.App.InputModels
{
    public class CreteTaskInputModel
    {
        public CreteTaskInputModel()
        {
            //this.Checkbox = new HashSet<string>();
        }

        public string Title { get; set; }
        public string DueDate { get; set; }
        public string Description { get; set; }
        public string Participants { get; set; }
    }
}
