namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var people = new List<Person>();
            while(input[0]!="End")
            {
                string name = input[0];
                string typeClass = input[1];
                
                if(!people.Any(x=>x.Name==name))
                {
                    Person person = new Person(name);
                    people.Add(person);
                }

                if(typeClass== "company")
                {
                    //•	“<Name> company <companyName> <department> <salary>
                    string companyName = input[2];
                    string department = input[3];
                    double salary = double.Parse(input[4]);

                    Company company = new Company(companyName, department, salary);

                    //if (people.Find(x => x.Name == name).Company != null)
                    //{
                    //    people.Find(x => x.Name == name).Company = null;
                    //}
                    people.Find(x => x.Name == name).Company=company;
                    //people.Find(x => x.Name == name).Company.CompanyName = companyName;
                    //people.Find(x => x.Name == name).Company.Department = department;
                    //people.Find(x => x.Name == name).Company.Salary = salary;
                }

                else if (typeClass == "pokemon")
                {
                    //•	“<Name> pokemon <pokemonName> <pokemonType>
                    string pokemonName = input[2];
                    string type = input[3];

                    //if (people.Find(x => x.Name == name).Pokemon.Any(y => y.PokemonName == pokemonName))
                    //{
                    //    people.Find(x => x.Name == name).Pokemon.RemoveAll(y => y.PokemonName == pokemonName);
                    //}

                    Pokemon pokemon = new Pokemon(pokemonName, type);
                    people.Find(x => x.Name == name).Pokemon.Add(pokemon);
                }

                else if (typeClass == "parents")
                {
                    //•	“< Name > parents<parentName> < parentBirthday >
                    string parentName = input[2];
                    string parentBirthday = input[3];
                    
                    //if(people.Find(x => x.Name == name).Parent.Any(y=>y.ParentName==parentName))
                    //{
                    //    people.Find(x => x.Name == name).Parent.RemoveAll(y => y.ParentName == parentName);
                    //}
                    Parent parent = new Parent(parentName, parentBirthday);
                    people.Find(x => x.Name == name).Parent.Add(parent);
                }

                else if (typeClass == "children")
                {
                    //•	“<Name> children <childName> <childBirthday>
                    string childName = input[2];
                    string childBirthday = input[3];

                    //if (people.Find(x => x.Name == name).Child.Any(y => y.ChildName == childName))
                    //{
                    //    people.Find(x => x.Name == name).Child.RemoveAll(y => y.ChildName == childName);
                    //}

                    Child child = new Child(childName, childBirthday);
                    people.Find(x => x.Name == name).Child.Add(child);
                }

                else if (typeClass == "car")
                {
                    //•	“<Name> car <carModel> <carSpeed>
                    string carModel = input[2];
                    int carSpeed = int.Parse(input[3]);

                    Car car = new Car(carModel, carSpeed);

                    //if (people.Find(x => x.Name == name).Car!=null)
                    //{
                    //    people.Find(x => x.Name == name).Car = null;
                    //}
                    
                    people.Find(x => x.Name == name).Car = car;

                    //people.Find(x => x.Name == name).Car.Model = carModel;
                    //people.Find(x => x.Name == name).Car.Speed = carSpeed;
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            string resultName = Console.ReadLine();

            foreach (var person in people.Where(x=>x.Name==resultName))
            {
                //if(person.Name==resultName)
                //{
                    Console.WriteLine(person);
                
                
            }
        }
    }
}
