using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else 
            {
                Console.WriteLine("Invalid value");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;            
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            
            for (var counter = 0; counter < grades.Count; counter++)
            {
                if(grades[counter] == 42.111)
                {
                    goto done;
                }

                result.Low = Math.Min(grades[counter], result.Low);
                result.High = Math.Max(grades[counter], result.High);
                result.Average += grades[counter];

            }; 
            result.Average /= grades.Count;
            done:
            return result;
        }

        private List<double> grades;
        public string Name;
    }
}


