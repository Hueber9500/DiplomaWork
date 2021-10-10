using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit;

namespace TimetableGeneratorTDD
{
    public class TeachersTests
    {
        [Fact]
        public void Generation()
        {
            var teachersFilePath = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Teachers.txt");
            var teachers = Utils.LoadTeachersFromFile(teachersFilePath);
        }
    }
}
