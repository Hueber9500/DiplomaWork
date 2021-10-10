using GeneticAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TimetableGeneratorTDD
{
    public class GeneTests
    {
        [Fact]
        public void Generation()
        {
            var elements = TimeSlot.Generate(TimeSpan.FromHours(10), TimeSpan.FromHours(19), TimeSpan.FromHours(1));
            GeneObject<TimeSlot>.Generate(elements);
        }
    }
}
