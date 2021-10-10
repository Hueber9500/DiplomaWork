using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    public class Group : ValidatorObject
    {
        public string Name { get; }
        public string Code { get; }
        public int StudentsCount { get; }
        public IEnumerable<Subject> Subjects { get; }

        public Group(string name, string code, int studentsCount)
        {
            Name = name;
            Code = code;
            StudentsCount = studentsCount;
            Subjects = new List<Subject>();

            Validate();
        }

        public void AddSubject(Subject subject)
        {
            if (subject == null) throw new ArgumentNullException("subject is null");

            if (!Subjects.Contains(subject) || Subjects.Any(s => s.Name == subject.Name))
                Subjects.Append(subject);
        }
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid name");

            if (string.IsNullOrWhiteSpace(Code)) throw new ArgumentException("Invalid code");

            if (StudentsCount <= 0) throw new ArgumentException("Students count should be more than 0");
        }
    }
}
