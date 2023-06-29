using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Tasking
    {

        public List<string> People { get; set; }


        public Tasking(List<string> people) { 
            this.People = people;
        }


        public void ListPeople()
        {
            foreach (var person in this.People)
            {
                Console.WriteLine(person);
            }
        }


    }
}
