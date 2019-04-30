using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Test.Models
{
    class PeopleService
    {

        private List<Person> people = null;

        public PeopleService()
        {
            people = new List<Person>();

            people.Add(new Person() { Name = "Mario", Surname = "Rossi" });
            people.Add(new Person() { Name = "Mattia", Surname = "Macchidani" });
            people.Add(new Person() { Name = "Giacomo", Surname = "Folli" });
            people.Add(new Person() { Name = "Diego", Surname = "Rastelli" });
            people.Add(new Person() { Name = "Pierluigi", Surname = "Altimari" });
            people.Add(new Person() { Name = "Emanuele", Surname = "D'Angelo" });
        }

        public IList<Person> People
        {
            get { return people; }
        }

    }
}
