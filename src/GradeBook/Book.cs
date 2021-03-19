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




        // A B C char takes a single character: value type, struct
        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;    
                            
            }
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else 
            {
                throw new ArgumentException($"invalid (nameof(grade))");
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
                result.Low = Math.Min(grades[counter], result.Low);
                result.High = Math.Max(grades[counter], result.High);
                result.Average += grades[counter];

            }; 
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.letter = 'D';
                    break; 

                default:
                    result.letter = 'F';
                    break;               
            }    
            return result;
        }

        private List<double> grades;

        public string Name 
        {
            get; 
            public set;
        
        }

       public const string CATEGORY = "scince";

        
    }
}


