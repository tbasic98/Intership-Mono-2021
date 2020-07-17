using System;
using System.Threading;

namespace ZooApp
{
    public class Horse : Animal
    {
        private int Count = 0;

        public Horse(string name) : base(name)
        {
            this.Legs = 4;
        }

        public Horse(string name, double weight, double height) : base(name)
        {
            this.Weight = weight;
            this.Height = height;
        }

        public string JumpingOver(double fenceHeight)
        {
            if(fenceHeight > Height/2)
            {
                return "You're not able to jump over this fence. It's too big!";
            }
            else
            {
                Count++;
                return "You successiful jumped over the fence! Great job!";
            }
        }

        public int NumberOfFences()
        {
            return Count;
        }
    }
}
