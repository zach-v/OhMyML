using System;
using System.Collections.Generic;
using System.Linq;
using OhMyML.SourceCode;
using OhMyML.SourceCode.MLType.Supervised_Learning;

namespace OhMyML
{
	static class OhMyMLRunnable_Example_SingleLinearRegression
	{
		// Example entry point
		static void Main()
		{
			// Example of data input
			float[] x = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
			float[] y = { 6, 6, 11, 17, 16, 20, 23, 23, 29, 33, 39 };

			// Creating a new LinearRegressor
			LinearRegressor lr = new LinearRegressor();

			// Setting the input by creating a holder of the data
			lr.Fit(x, y);

			// Getting the output predictions from our learning container
			float[] predictions = lr.Predict(x).ToArray();

			// Displaying the output in console
			Console.WriteLine("Predictions:");
			Console.WriteLine($"{string.Join(", ", predictions.Select(p => p.ToString()))}");
			Console.WriteLine("Actual Value: ");
			Console.WriteLine($"{string.Join(", ", y.Select(p => p.ToString()))}");
			Console.ReadLine();
		}
	}
}
