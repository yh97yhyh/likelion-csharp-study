using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stidy17
{
    class Person
    {
        //private string name;
        public string Name { get; set; }
        public int Count { get; private set;  }

        public Person()
        {
            //this.name = "이름없음";
            Name = "이름없음";
        }
        public Person(string name)
        {
            //this.name = name;
            Name = name;
        }

        //public void SetName(string newName) // Setter
        //{
        //    name = newName;
        //}

        //public string GetName() // Getter
        //{
        //    return name;
        //}

    }

    class Program
    {
        static void Main(string[] args)
        {
            // get/est, Property

            var person = new Person();
            //person.SetName("내이름");
            person.Name = "내이름";
            Console.WriteLine(person.Name);
        }
    }
}
