using System;
using System.Collections;
using System.Collections.Generic;

namespace OhMyML.SourceCode
{
	public static class OhMath
	{
		public static double EuclideanDistance(double[] sampleOne, double[] sampleTwo)
		{
			double d = 0.0;

			for (int i = 0; i < sampleOne.Length; i++)
			{
				double temp = sampleOne[i] - sampleTwo[i];
				d += temp * temp;
			}

			return Math.Sqrt(d);
		}
	}
}
