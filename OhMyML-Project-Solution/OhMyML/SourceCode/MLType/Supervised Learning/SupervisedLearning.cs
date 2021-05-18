using System;
using System.Collections.Generic;
using System.Linq;
using OhMyML.SourceCode.MLType.SupervisedLearning;

namespace OhMyML.SourceCode.MLType.Supervised_Learning
{
	public class SupervisedLearning<I, L, O> : MLTypeInterface<OhMath.DimensionalHolder<I>, L, IEnumerable<O>> where L : IRegressor
	{
		private LinearRegressor linearRegressor;
		private void SingleLinearRegression(OhMath.DimensionalHolder<I> input)
		{
			linearRegressor = new LinearRegressor();

			// We assume the holder has 2 inputs 
			if (input.items.Count >= 1)
				linearRegressor.Fit(input.items[0].OfType<float>(), input.items[1].OfType<float>());
			else
				Console.WriteLine("Dimensional holder contains no items");
		}

		private IEnumerable<O> SingleLinearRegressionPredict(IEnumerable<O> input)
		{
			return linearRegressor.Predict(input.OfType<float>()).Cast<O>();
		}

		public static void MultipleLinearRegression()
		{
			// Hard coded for now
			double[,] X = { { 1, 2, 3},
							{ 2, 9, 11 },
							{ 56, 111, 66}};

			double[,] y = { { 6 }, { 6 }, { 11 } };

			MultipleLinearRegressor linearRegressor = new MultipleLinearRegressor();
			linearRegressor.Fit(X, y);

			double prediction = linearRegressor.Predict(new double[,] { { 3 }, { 5 }, { 7 } });

			Console.WriteLine($"Prediction: {prediction}");
		}
		
		public void SetInput(OhMath.DimensionalHolder<I> input)
		{
			if (typeof(L) == typeof(LinearRegressor))
				SingleLinearRegression(input);
		}

		public IEnumerable<O> GetOutput(IEnumerable<O> input)
		{
			if (typeof(L) == typeof(LinearRegressor))
				return SingleLinearRegressionPredict(input);
			return null;
		}
	}
}
