using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers;
        private List<Person> adults;

        public List<Person> Adults
        {
            get { return this.adults; }
            set { this.adults = value; }
        }

        public void ListOfAdults(Person person)
        {
            if (person.Age > 30)
            {
                this.Adults.Add(person);
            }
        }

        public List<Person> FamilyMembers
        {
            get { return this.familyMembers; }
            set { this.familyMembers = value; }
        }

        public Family()
        {
            this.FamilyMembers = new List<Person>();
        }

        public void AddMember (Person person)
        {
            this.FamilyMembers.Add(person);
        }

        public Person GetOldestMember()
        {
            return FamilyMembers.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}
