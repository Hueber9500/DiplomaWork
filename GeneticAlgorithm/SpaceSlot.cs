using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm
{
    public class SpaceSlot : ValidatorObject
    {
        public int Capacity { get; }

        public SpaceSlot(int capacity)
        {
            Capacity = capacity;

            Validate();
        }

        protected override void Validate()
        {
            if (Capacity <= 0) throw new ArgumentException("Capacity is not enough");
        }
    }
}
