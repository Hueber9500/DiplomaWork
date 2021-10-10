using System;
using System.Text.RegularExpressions;

namespace GeneticAlgorithm
{
    public class Teacher:ValidatorObject
    {
        public string Name { get; }

        public Teacher(string name)
        {
            Name = name;
        }

        protected override void Validate()
        {
            Regex nameRegex = new Regex("^[a-z A-Z]+$");

            if (string.IsNullOrWhiteSpace(Name) || !nameRegex.IsMatch(Name)) throw new ArgumentException("Invalid name");
        }
    }
}
