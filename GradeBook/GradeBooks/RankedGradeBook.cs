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


            if (Students.Count < 5)
            {

                throw new InvalidOperationException("Number of Students are less than 5");
            }
            double[] classAverageGrades = new double[Students.Count];

            // 20% of the class
            var twentyPercentOfClass = (int)Math.Ceiling(Students.Count * 0.2);
            var i = 0;

            foreach (var student in Students)
            {
                classAverageGrades[i] = student.AverageGrade;
                i++;
            }

            // sort the aray

            Array.Sort(classAverageGrades);
            Array.Reverse(classAverageGrades);

            // find index of averageGrade provided in class AverageGrade
            // Compair with the 20% multiplier to see where it fits. 

            var indexOfAverageGrade = Array.IndexOf(classAverageGrades, averageGrade) + 1;

            var section = indexOfAverageGrade / twentyPercentOfClass;


            if (1 > section && section >= 0)
            {
                return 'A';
            }
            else if (2 > section && section >= 1)
            {
                return 'B';
            }
            else if (3 > section && section >= 2)
            {
                return 'C';
            }
            else if (4 > section && section >= 3)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
