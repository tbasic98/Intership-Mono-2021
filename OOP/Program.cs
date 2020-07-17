using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZooApp
{

    class Program
    {
        static List<Cat> cats = new List<Cat>();
        static List<Horse> horses = new List<Horse>();
        static List<Dog> dogs = new List<Dog>();
        static List<Zookeeper> zookeepers = new List<Zookeeper>();


        static bool exists = false;
        static void Main(string[] args)
        {
            cats.Add(new Cat("koska"));
            cats.Add(new Cat("oliver"));
            cats.Add(new Cat("guliver"));
            cats.Add(new Cat("cosmo"));
            cats.Add(new Cat("dara"));

            horses.Add(new Horse("tango", 750, 175));
            horses.Add(new Horse("janje", 650, 202));
            horses.Add(new Horse("mazonja", 152, 210));
            horses.Add(new Horse("tiho", 356, 230));

            dogs.Add(new Dog("lux"));
            dogs.Add(new Dog("don"));
            dogs.Add(new Dog("aira"));
            dogs.Add(new Dog("lea"));

            zookeepers.Add(new Zookeeper("adam"));
            zookeepers.Add(new Zookeeper("uwe"));
            zookeepers.Add(new Zookeeper("maria"));
            zookeepers.Add(new Zookeeper("ken"));


            Console.WriteLine("Welcome to ZooApp!\n");

            string input;
            do
            {
                Console.WriteLine("Insert animal or person, for end insert 'end': ");

                input = Console.ReadLine().ToLower();

                if (!input.Equals("end"))
                {
                    switch (input)
                    {
                        case "cat":
                            caseCat();
                            break;
                        case "horse":
                            caseHorse();
                            break;
                        case "dog":
                            caseDog();
                            break;
                        case "zookeper":
                            caseZookeper();
                            break;
                        default:
                            Console.WriteLine("Invalid input! Please enter: cat, dog, horse or zookeper !!");
                            break;

                    }
                }

            } while (input.ToLower() != "end");



        }

        public static void caseCat()
        {
            Console.WriteLine("Insert cat name: ");
            var name = Console.ReadLine().ToLower();
            foreach (var cat in cats)
            {
                if (cat.Name.Equals(name))
                {
                    exists = true;
                    Console.WriteLine("Please enter command for: {0}", cat.Name);
                    var command = Console.ReadLine().ToLower();
                    switch (command)
                    {
                        case "catch mice":
                            Console.WriteLine(cat.CatchMice());
                            break;
                        case "sleep":
                            Console.WriteLine(cat.Sleep());
                            break;
                        case "eat":
                            Console.WriteLine("Enter number of bites: ");
                            var bites = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(cat.Eat(bites));
                            break;
                        case "wake up":
                            Console.WriteLine(cat.WakeUp());
                            break;
                        default:
                            Console.WriteLine("Invalid command!!");
                            break;
                    }
                }
            }
            if (!exists)
            {
                Console.WriteLine("Cat {0} does not exist!", name);
            }

        }

        public static void caseHorse()
        {
            Console.WriteLine("Insert horse name: ");
            var name = Console.ReadLine().ToLower();
            foreach (var horse in horses)
            {
                if (horse.Name.Equals(name))
                {
                    exists = true;
                    Console.WriteLine("Please enter command for: {0}", horse.Name);
                    var command = Console.ReadLine().ToLower();
                    switch (command)
                    {
                        case "jumping over fence":
                            Console.WriteLine("Enter the hight of a fence: ");
                            var hight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(horse.JumpingOver(hight));
                            break;
                        case "number of fences":
                            Console.WriteLine(horse.NumberOfFences());
                            break;
                        case "sleep":
                            Console.WriteLine(horse.Sleep());
                            break;
                        case "eat":
                            Console.WriteLine("Enter number of bites: ");
                            var bites = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(horse.Eat(bites));
                            break;
                        case "wake up":
                            Console.WriteLine(horse.WakeUp());
                            break;
                        default:
                            Console.WriteLine("Invalid command!!");
                            break;
                    }
                }
            }
            if (!exists)
            {
                Console.WriteLine("Horse {0} does not exist!", name);
            }
        }

        public static void caseDog()
        {
            Console.WriteLine("Insert dog name: ");
            var name = Console.ReadLine().ToLower();
            foreach (var dog in dogs)
            {
                if (dog.Name.Equals(name))
                {
                    exists = true;
                    Console.WriteLine("Please enter command for: {0}", dog.Name);
                    var command = Console.ReadLine().ToLower();
                    switch (command)
                    {
                        case "fetch":
                            Console.WriteLine("Enter which kind of a toy dog is trying to fetch: ");
                            var toy = Console.ReadLine();
                            Console.WriteLine(dog.Fetch(toy));
                            break;
                        case "sleep":
                            Console.WriteLine(dog.Sleep());
                            break;
                        case "eat":
                            Console.WriteLine("Enter number of bites: ");
                            var bites = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(dog.Eat(bites));
                            break;
                        case "wake up":
                            Console.WriteLine(dog.WakeUp());
                            break;
                        default:
                            Console.WriteLine("Invalid command!!");
                            break;
                    }
                }
            }
            if (!exists)
            {
                Console.WriteLine("Dog {0} does not exist!", name);
            }
        }

        public static void caseZookeper()
        {
            Console.WriteLine("Insert zookepers name: ");
            var name = Console.ReadLine().ToLower();
            foreach (var zookeper in zookeepers)
            {
                if (zookeper.Name.Equals(name))
                {
                    exists = true;
                    Console.WriteLine("Please enter command for: {0}", zookeper.Name);
                    var command = Console.ReadLine().ToLower();
                    switch (command)
                    {
                        case "introduce":
                            Console.WriteLine("My name is" + name);
                            break;
                        case "feed animal":
                            Console.WriteLine("What animal do you want to feed? (cat, horse, dog)");
                            var animal = Console.ReadLine().ToLower();
                            switch (animal)
                            {
                                case "cat":
                                    Console.WriteLine("Enter cat name: ");
                                    var catName = Console.ReadLine().ToLower();
                                    foreach (var cat in cats)
                                    {
                                        if (cat.Name.ToLower().Equals(catName))
                                        {
                                            zookeper.FeedAnimal("cat");
                                        }
                                    }
                                    break;
                                case "horse":
                                    Console.WriteLine("Enter horse name: ");
                                    var horseName = Console.ReadLine().ToLower();
                                    foreach (var horse in horses)
                                    {
                                        if (horse.Name.ToLower().Equals(horseName))
                                        {
                                            zookeper.FeedAnimal("horse");
                                        }
                                    }
                                    break;
                                case "dog":
                                    Console.WriteLine("Enter dog name: ");
                                    var dogName = Console.ReadLine().ToLower();
                                    foreach (var dog in dogs)
                                    {
                                        if (dog.Name.Equals(dogName))
                                        {
                                            zookeper.FeedAnimal("dog");
                                        }
                                    }
                                    break;

                                default:
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid command!!");
                            break;
                    }
                }
            }
            if (!exists)
            {
                Console.WriteLine("Zookeeper {0} does not exist!", name);
            }
        }
    }
}
