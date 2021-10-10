using GeneticAlgorithm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace TimetableGeneratorTDD
{
    static class Utils
    {
        internal static IEnumerable<Teacher> LoadTeachersAndModulesFromYAML(string yamlPath)
        {
            ////
        }

        internal static IEnumerable<Teacher> LoadTeachersFromFile(string filePath)
        {
            var teachers = new List<Teacher>();
            using(var fs = new StreamReader(File.OpenRead(filePath)))
            {
                string line = null;
                while((line = fs.ReadLine()) != null)
                {
                    teachers.Add(new Teacher(RemoveProfessionalTitlesFromName(line)));       
                }
            }

            return teachers;
        }

        private static string RemoveProfessionalTitlesFromName(string name)
        {
            char[] professionalTitleContainingChars = new char[] { '.', '-' };
            return string.Join(' ', name.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .SkipWhile(el => el.Any(e => professionalTitleContainingChars.Contains(e))));
        }
    }
}
