using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace OhMyML.SourceCode
{
	public static class OhMath
	{
		public static double EuclideanDistance(IList<double> sampleOne, IList<double> sampleTwo)
		{
			double d = 0.0;

			for (int i = 0; i < sampleOne.Count; i++)
			{
				double temp = sampleOne[i] - sampleTwo[i];
				d += temp * temp;
			}

			return Math.Sqrt(d);
		}

        public static double GetDistance(IList<double> sampleOne, IList<double> sampleTwo)
		{
			ParallelQuery<double> differences = sampleOne.AsParallel().Zip(sampleTwo, (s1, s2) => s1 - s2);
			return differences.Sum(x => x * x);
		}
	}
}
