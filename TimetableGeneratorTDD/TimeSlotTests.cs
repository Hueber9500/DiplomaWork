using GeneticAlgorithm;
using System;
using System.Collections.Generic;
using Xunit;

namespace TimetableGeneratorTDD
{
    public class TimeSlotTests
    {
        [Theory]
        [MemberData(nameof(GetStartTimeEndTimeIntervalsAndExpectedCount))]  
        public void Generation(TimeSpan startTime, TimeSpan endTime, TimeSpan interval, int expectedIntervals)
        {
            TimeSlot[] generatedSlots = TimeSlot.Generate(startTime, endTime, interval);

            Assert.Equal(expectedIntervals, generatedSlots.Length / TimeSlot.AvailableDays.Length);
        }

        public static IEnumerable<object[]> GetStartTimeEndTimeIntervalsAndExpectedCount()
        {
            yield return new object[] { TimeSpan.FromHours(10), TimeSpan.FromHours(18), TimeSpan.FromHours(1), 8 };
            yield return new object[] { TimeSpan.FromHours(10), TimeSpan.FromHours(18), TimeSpan.FromMinutes(30), 16 };
            yield return new object[] { TimeSpan.FromHours(7), TimeSpan.FromHours(19), TimeSpan.FromMinutes(15), 48 };
        }
    }
}
