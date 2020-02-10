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
				throw new InvalidOperationException("Few than five students");
			}

			double classMax = CalculateClassMax();
			double classMin = CalculateClassMin();
			double classRange = classMax - classMin;
			double classQuintile = classRange / 5;
			if (averageGrade >= (classMax - classQuintile))
			{
				return 'A';
			}
			if (averageGrade > (classMax - classQuintile*2) && averageGrade < (classMax - classQuintile))
			{
				return 'B';
			}
			if (averageGrade > (classMax - classQuintile * 3) && averageGrade < (classMax - classQuintile*2))
			{
				return 'C';
			}
			if (averageGrade > (classMax - classQuintile * 4) && averageGrade < (classMax - classQuintile*3))
			{
				return 'D';
			}
			else
			{
				return 'F';
			}
		}

		private double CalculateClassMin()
		{
			double min = double.MaxValue;
			foreach (Student student in Students)
			{
				if (student.AverageGrade < min) min = student.AverageGrade;
			}
			return min;
		}

		private double CalculateClassMax()
		{
			double max = double.MinValue;
			foreach (Student student in Students)
			{
				if (student.AverageGrade > max) max = student.AverageGrade;
			}
			return max;
		}
	}
}
