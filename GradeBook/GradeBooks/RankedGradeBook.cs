using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {

            // List<double> classAverageGrades = new List<double>();

            double[] classAverageGrades = new double[Students.Count];

            if (Students.Count > 5)
            {
                // 20% of the class
                var twentyPercentOfClass = Students.Count * 0.2;
                var i = 0;

                foreach (var student in Students)
                {
                    classAverageGrades[i] = student.AverageGrade;
                    i++;
                }

                // find index of averageGrade provided in class AverageGrade
                // Compair with the 20% multiplier to see where it fits. 

                var indexOfAverageGrade = Array.IndexOf(classAverageGrades, averageGrade) + 1;

                var section = indexOfAverageGrade % twentyPercentOfClass;


                if (2 > section && section > 0)
                {
                    averageGrade = 90;
                }
                else if (3 > section && section > 2)
                {
                    averageGrade = 80;
                }
                else if (3 > section && section > 2)
                {
                    averageGrade = 70;
                }
                else if (3 > section && section > 2)
                {
                    averageGrade = 60;
                }

                //foreach (var student in Students)
                // {
                //classAverageGrades.Add(student.AverageGrade);
                // }
            }
            else
            {
                averageGrade = 0;
                Console.WriteLine("InvalidOperationException");
            }



            return base.GetLetterGrade(averageGrade);
        }
    }
}
