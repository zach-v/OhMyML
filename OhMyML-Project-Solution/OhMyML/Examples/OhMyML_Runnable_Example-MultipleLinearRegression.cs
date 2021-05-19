using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearRegression;
using OhMyML.SourceCode;
using OhMyML.SourceCode.MLType.Supervised_Learning;

namespace OhMyML
{
	//!!!!!!!!!! not working yet :(
	static class OhMyMLRunnable_Example_MultipleLinearRegression
	{
		// Example entry point
		static void main()
		{
			// Example of data input
			double[,] x = { { 1, 2, 3},
				{ 2, 9, 11 },
				{ 56, 111, 66}};

			double[,] y = { { 6 }, { 6 }, { 11 } };

			// Creating a new MultipleLinearRegressor
			MultipleLinearRegressor mlr = new MultipleLinearRegressor();

			// Fitting the x and y
			mlr.Fit(x, y);

			// Getting the output predictions from our learning container
			double[,] sample = {{3}, {5}, {7}};
			double prediction = mlr.Predict(sample);

			// Displaying the output in console
			Console.WriteLine($"Prediction: {prediction}");
		}
	}
}
