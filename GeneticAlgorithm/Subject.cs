using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    public class Subject:ValidatorObject
    {
        public string Name { get; }
        public int TimeSlotsNeeded { get; }
        public string Code { get; }
        public IEnumerable<Teacher> Teachers { get; }
        public Subject(string name, int neededTimeSlots)
        {
            Name = name;
            TimeSlotsNeeded = neededTimeSlots;
            Teachers = new List<Teacher>();
            Code = GetCodeFromName(Name);
            Validate();
        }
        
        public void AssignTeacher(Teacher t)
        {
            if (t == null) throw new ArgumentNullException("Teacher is null");

            if (!Teachers.Contains(t) || !Teachers.Any(teacher=>teacher.Name == t.Name))
                Teachers.Append(t);
        }
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Code)) throw new ArgumentException("Invalid code");

            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid name");
            
            if (TimeSlotsNeeded <= 0) throw new ArgumentException("Invalid timeslots");
        }
        private string GetCodeFromName(string name)
        {
            return string.Join(string.Empty, name.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(el => el.Length >= 3)
                .Select(el => el[0].ToString().ToUpper()));
        }
    }
}
