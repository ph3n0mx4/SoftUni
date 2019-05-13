using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseExtend
{
    public class Database
    {
        private const int defaultSize = 16;
        private Person[] people;
        private int index;

        public Database(params Person[] people)
        {
            this.index = 0;
            this.people = new Person[defaultSize];
            this.ValidateCollectionSize(people);
            this.DatabaseElements = people;
        }

        //public IReadOnlyCollection<Person> People = this.people;

        public Person[] DatabaseElements
        {
            get
            {
                var nums = new List<Person>();
                for (int i = 0; i < this.index; i++)
                {
                    nums.Add(people[i]);
                }
                return nums.ToArray();
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    this.people[this.index] = value[i];
                    this.index++;
                }
            }
        }

        public void Add(string username, long id)
        {
            if (this.index >= 16)
            {
                throw new InvalidOperationException("Database is full");
            }

            if (people.Any(x =>x!=null && x.Id == id))
            {
                throw new InvalidOperationException("There are already users with this username");
            }

            if(people.Any(x=> x != null && x.Username==username))
            {
                throw new InvalidOperationException("There are already users with this id");
            }

            
            var person = new Person(username, id);
            this.people[this.index] = person;
            this.index++;
        }

        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Database is empty");
            }
            this.people[this.index - 1] = null;
            this.index--;
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username can not be null or empty");
            }

            if (!people.Any(x=> x != null && x.Username==username))
            {
                throw new InvalidOperationException("Person with this username doesn't exist");
            }

            return people.First(x => x.Username == username);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id can not be negative");
            }

            if (!people.Any(x=> x != null && x.Id==id))
            {
                throw new InvalidOperationException("Person with this id doesn't exist");
            }

            return people.First(x => x.Id == id);
        }

        private void ValidateCollectionSize(Person[] collection)
        {
            if (collection.Length > 16 || collection.Length < 1)
            {
                throw new InvalidOperationException("Invalid collection size");
            }
        }

        

        public Person[] Fetch()
        {
            return this.people.Take(this.index).ToArray();
        }
    }
}
