using System;
using System.Linq;
using OhMyML.SourceCode.MLType.SupervisedLearning;

namespace OhMyML.SourceCode
{
    public class SupervisedLearning
    {

        public static void SingleLinearRegression(string[] args)
        {
            // Hard Coded for now
            float[] X = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            float[] y = { 6, 6, 11, 17, 16, 20, 23, 23, 29, 33, 39 };

            var linearRegressor = new LinearRegressor();
            linearRegressor.Fit(X, y);

            var predictions = linearRegressor.Predict(X);

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

            var linearRegressor = new MultipleLinearRegressor();
            linearRegressor.Fit(X, y);

            var prediction = linearRegressor.Predict(new double[,] { { 3 }, { 5 }, { 7 } });

            Console.WriteLine($"Prediction: {prediction}");
        }
    }
}
