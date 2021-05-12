using System;
using System.Linq;
using OhMyML.SourceCode.MLType;
using OhMyML.SourceCode.MLType.Supervised_Learning;
using OhMyML.SourceCode.MLType.SupervisedLearning;

namespace OhMyML.SourceCode
{
	public class SupervisedLearning<I, L, O> : MLTypeInterface<I, L, O> where L : IRegressor
	{
		public static void SingleLinearRegression(string[] args)
		{
			// Hard Coded for now
			float[] X = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
			float[] y = { 6, 6, 11, 17, 16, 20, 23, 23, 29, 33, 39 };

			LinearRegressor linearRegressor = new LinearRegressor();
			linearRegressor.Fit(X, y);

			float[] predictions = linearRegressor.Predict(X);

			Console.WriteLine("Predictions:");
			Console.WriteLine($"{string.Join(", ", predictions.Select(p => p.ToString()))}");

			Console.WriteLine("Actual Value: ");
			Console.WriteLine($"{string.Join(", ", y.Select(p => p.ToString()))}");
			Console.ReadLine();
		}

		public static void MultipleLinearRegression(string[] args)
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

		public void SetInput(I input)
		{
			if (typeof(L) == typeof(MultipleLinearRegressor))
				throw new NotImplementedException();
		}

		public O GetOutput()
		{
			throw new NotImplementedException();
		}
	}
}
