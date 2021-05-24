using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OhMyML.SourceCode.MLType.Supervised_Learning;

namespace OhMyML.SourceCode.MLType.SupervisedLearning
{
	public class KNearestNeighbor
	{
		public int[] TestKnnCase(IList<double[]> trainSamples, IList<double[]> testSamples, IList<int[]> trainClasses, int K)
		{
			int[] testResults = new int[testSamples.Count()];
			int testNumber = testSamples.Count();
			int trainNumber = trainSamples.Count();

			double[][] distances = new double[trainNumber][];
			for(int i = 0; i < testNumber; i++)
            {
				distances[i] = new double[2];
            }

			for(int tst = 0; tst < testNumber; tst++)
            {
				Parallel.For(0, trainNumber, trn =>
				{
					double dist = OhMath.GetDistance(testSamples[tst], trainSamples[trn]);
					distances[trn][0] = dist;
					distances[trn][1] = trn;
				});

				ParallelQuery<double[]> votingDistances = distances.AsParallel().OrderBy(t => t[0]).Take(K);

				double yea = 0.0;
				double nay = 0.0;

				foreach(double[] voter in votingDistances)
                {
					yea = votingDistances.AsParallel().Count(voter => trainClasses[voter.index] == 1);
					nay = votingDistances.Count() - yea;
				}

				if (yea > nay)
                {
					testResults[tst] = 1;
                }
				else
                {
					testResults[tst] = 0;
                }
            }
			return testResults;
        }
	}
}
