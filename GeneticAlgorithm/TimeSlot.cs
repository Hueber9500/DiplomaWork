using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GeneticAlgorithm
{
    public class TimeSlot : ValidatorObject
    {
        private const int minTimeSlotIntervalInMinutes = 5;

        public static readonly DayOfWeek[] AvailableDays = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday };
        public TimeSpan StartTime { get; }

        public TimeSpan EndTime { get; }

        public DayOfWeek DayOfWeek { get; }

        public TimeSlot(TimeSpan startTime, TimeSpan endTime, DayOfWeek dayOfWeek)
        {
            StartTime = startTime;
            EndTime = endTime;
            DayOfWeek = dayOfWeek;

            Validate();
        }

        protected override void Validate()
        {
            if (StartTime > EndTime) 
                throw new ArgumentException("start time is invalid");

            if ((EndTime - StartTime).TotalMinutes < minTimeSlotIntervalInMinutes) 
                throw new ArgumentException($"interval is less than {minTimeSlotIntervalInMinutes} minutes");
        }

        /// <summary>
        /// Generate timeslots for day and time
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="interval"></param>
        /// <returns>array of timeslots ordered by days</returns>
        public static TimeSlot[] Generate(TimeSpan startTime, TimeSpan endTime, TimeSpan interval)
        {
            int timeSlots = (int)((endTime - startTime) / interval);
            TimeSlot[] slots = new TimeSlot[timeSlots * AvailableDays.Length];

            for (int j = 0; j < AvailableDays.Length; j++)                
            {
                for (int i = 0; i < timeSlots; i++)
                {
                    slots[j * timeSlots + i] = new TimeSlot(startTime + (i) * interval, startTime + (i + 1) * interval, AvailableDays[j]);
                }
            }

            return slots;
        }
    }
}
