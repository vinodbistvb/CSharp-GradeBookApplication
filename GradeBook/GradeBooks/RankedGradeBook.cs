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

            if (Students.Count < 5)
            {

                throw new InvalidOperationException("Number of Students are less than 5");
            }
            else
            {
                double[] classAverageGrades = new double[Students.Count];

                // 20% of the class
                var twentyPercentOfClass = (int)Math.Ceiling(Students.Count * 0.2);
                var i = 0;

                foreach (var student in Students)
                {
                    classAverageGrades[i] = student.AverageGrade;
                    i++;
                }

                // sort the array

                Array.Sort(classAverageGrades);
                Array.Reverse(classAverageGrades);

                // find index of averageGrade provided in class AverageGrade
                // Compair with the 20% multiplier to see where it fits. 

                if (averageGrade >= classAverageGrades[twentyPercentOfClass - 1])
                {
                    return 'A';
                }
                else if (averageGrade >= classAverageGrades[twentyPercentOfClass * 2 - 1])
                {
                    return 'B';
                }
                else if (averageGrade >= classAverageGrades[twentyPercentOfClass * 3 - 1])
                {
                    return 'C';
                }
                else if (averageGrade >= classAverageGrades[twentyPercentOfClass * 4 - 1])
                {
                    return 'D';
                }
                else
                {
                    return 'F';
                }
            }




        }
    }
}
