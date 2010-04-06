using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using V4.Dynamics;

namespace V4
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var users = new User[]
            {
                new User { Name= "Tom", Age = 12 },
                new User { Name = "Jerry", Age=10 }
            };

            dynamic b = new XmlMarkupBuilder();
            var xml = b.persons(
                from u in users
                select b.person(u.Name, age: u.Age));

            Console.WriteLine(xml);
            Console.ReadLine();
        }
    }
}
