using GeneticAlgorithm;
using System.Collections.Generic;
using Xunit;

namespace TimetableGeneratorTDD
{
    public class SubjectsTests
    {
        [Fact]
        public void Generation()
        {
            var teachers = new List<Teacher>()
            {
                new Teacher("Nedqlko Nikolov"),
                new Teacher("Milena Karova"),
                new Teacher("Violeta Bozhikova"),
                new Teacher("Geo Kunev"),
                new Teacher("Hristo Nenov"),
                new Teacher("Antoaneta Ivanova")
            };

            var subjects = new List<Subject>()
            {
                new Subject("Sintez i analiz na algoritmi", 2),
                new Subject("Bazi danni", 2)
            };


        }

        
        [Theory]
        [MemberData(nameof(GetSubjectNameAndDurationAndExpectedCode))]
        public void CheckCodeGenerationFromName(string name, int timeslotsDuration, string expectedCode)
        {
            var subject = new Subject(name, timeslotsDuration);
            Assert.Equal(expectedCode, subject.Code);
        }

        public static IEnumerable<object[]> GetSubjectNameAndDurationAndExpectedCode()
        {
            yield return new object[] { "Синтез и анализ на алгоритми", 4, "САА" };
        }
    }
}
