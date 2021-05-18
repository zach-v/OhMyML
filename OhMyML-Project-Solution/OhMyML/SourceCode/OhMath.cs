using System;
namespace OhMyML.SourceCode
{
    internal static class OhMath
    {
        public static double EuclideanDistance(double[] sampleOne, double[] sampleTwo)
        {
            double d = 0.0;

            for(int i = 0; i < sampleOne.Length; i++)
            {
                double temp = sampleOne[i] - sampleTwo[i];
                d += temp * temp;
            }

            return Math.Sqrt(d);
        }
    }
}
