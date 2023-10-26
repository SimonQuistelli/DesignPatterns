using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    public class ProtoTypeTest
    {
        public static void TestProtoTypeDP()
        {
            Person original = new Person(1, "Simon", 52, new DateTime(1971, 7, 24));
            Person shallowclone = original.ShallowCopy();
            Person deepClone = original.DeepCopy();

            DisplayInfo("Original Person", original);
            DisplayInfo("Shallow Clone", shallowclone);
            DisplayInfo("Deep Clone", deepClone);

            Console.WriteLine();
            Console.WriteLine("Update Shallow Clone");
            Console.WriteLine("ID = 2, Name = Paul, Age = 51, DOB = 24/07/1972");
            Console.WriteLine("Note how orginal person ID is change due to being object");
            Console.WriteLine();

            shallowclone.ID_Info.ID = 2;
            shallowclone.Name = "Paul";
            shallowclone.Age = 51;
            shallowclone.DOB = new DateTime(1972, 7, 24);

            DisplayInfo("Original Person", original);
            DisplayInfo("Shallow Clone", shallowclone);

            Console.WriteLine();
            Console.WriteLine("Update Deep Clone");
            Console.WriteLine("ID = 3, Name = James, Age = 50, DOB = 24/07/1973");
            Console.WriteLine("Original person should not change");
            Console.WriteLine();

            deepClone.ID_Info.ID = 3;
            deepClone.Name = "James";
            deepClone.Age = 50;
            deepClone.DOB = new DateTime(1973, 7, 24);

            DisplayInfo("Original Person", original);
            DisplayInfo("Deep Clone", deepClone);
        }

        static void DisplayInfo(string name, Person p)
        {
            Console.WriteLine("{0} ID {1}", name, p.ID_Info.ID);
            Console.WriteLine("{0} Name {1}", name, p.Name);
            Console.WriteLine("{0} Age {1}", name, p.Age);
            Console.WriteLine("{0} DOB {1}", name, p.DOB.ToString("dd/MM/yyyy"));
            Console.WriteLine();
        }
 
    }

    public class Person
    {
        public PersonIDInfo ID_Info { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
  
        public Person(int id, string name, int age, DateTime dob)
        {
            ID_Info = new PersonIDInfo(id);
            Name = name;
            Age = age;
            DOB = dob;
        }

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            //person.Name = this.Name;
            clone.ID_Info = new PersonIDInfo(this.ID_Info.ID);
            return clone;
        }
    }

    public class PersonIDInfo
    {
        public int ID { get; set; }

        public PersonIDInfo(int id)
        {
            ID = id;
        }
    }
}
