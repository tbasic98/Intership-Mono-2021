using System;

namespace ZooApp
{
    public class Zookeeper : IPerson
    {
        public string Name;
        public  int Age;

        public Zookeeper(string name)
        {
            this.Name = name;
        }

        public void FeedAnimal(String animal)
        {
            if (animal.Equals("cat"))
            {
                Console.WriteLine("Cat fed");
            }
            else if (animal.Equals("dog"))
            {
                Console.WriteLine("Dog is fed");
            }
            else if(animal.Equals("horse"))
            {
                Console.WriteLine("Horse is fed");
            }
        }

        public string Introduce(string name)
        {
            return "Hello! I am zookeper " + name;
        }
    }
}
