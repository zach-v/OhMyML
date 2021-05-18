using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace OhMyML.SourceCode.MLType.Supervised_Learning
{
    /// <summary>
    /// Simple Linear Regression implementation
    /// Performs linear regression on one feature and on output value
    /// </summary>
    public class LinearRegressor : Regressor<IEnumerable<float>>
    {
        private float _b0;
        private float _b1;

        public LinearRegressor()
        {
            _b0 = 0;
            _b1 = 1;
        }

        /// <summary>
        /// Train the Single Linear Regression algoritm.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Fit(IEnumerable<float> x, IEnumerable<float> y)
        {
            float ssxy = x.Zip(y, (a, b) => a * b).Sum() - x.Count() * x.Average() * y.Average();
            float ssxx = x.Zip(x, (a, b) => a * b).Sum() - x.Count() * x.Average() * x.Average();

            _b1 = ssxy / ssxx;
            _b0 = y.Average() - _b1 * x.Average();
        }

        /// <summary>
        /// Predict new values(Single Regression).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public IEnumerable<float> Predict(IEnumerable<float> x)
        {
            return x.Select(i => _b0 + i * _b1).ToArray();
        }
    }

    /// <summary>
    /// Implementation of Multiple Linear Regression
    /// </summary>
    public class MultipleLinearRegressor : Regressor<double[,], double>
    {
        private double _b;
        private double[] _w;

        public MultipleLinearRegressor()
        {
            _b = 0;
        }

        /// <summary>
        /// Train the Multiple Linear Regression Algorithm
        /// </summary>
        /// <param name="X"></param>
        /// <param name="y"></param>
        public void Fit(double[,] X, double[,] y)
        {
            Matrix<double> input = ExtendInputWithOnes(X);
            Matrix<double> output = Matrix<double>.Build.DenseOfArray(y);

            Vector<double> coefficients = ((input.Transpose() * input).Inverse() * input.Transpose() * output)
                                .Transpose().Row(0);

            _b = coefficients.ElementAt(0);
            _w = SubArray(coefficients.ToArray(), 1, X.GetLength(1));
        }

        /// <summary>
        /// Predict new values (Multiple Regression).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Predict(double[,] x)
        {
            Matrix<double> input = Matrix<double>.Build.DenseOfArray(x).Transpose();
            Vector<double> w = Vector<double>.Build.DenseOfArray(_w);
            return input.Multiply(w).ToArray().Sum() + _b;
        }

        /// <summary>
        /// Add 'ones' to the input array to model coefficient b in data
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        private Matrix<double> ExtendInputWithOnes(double[,] X)
        {
            Matrix<double> ones = Matrix<double>.Build.Dense(X.GetLength(0), 1, 1d);
            Matrix<double> extendedX = ones.Append(Matrix<double>.Build.DenseOfArray(X));
            return extendedX;
        }

        private double[] SubArray(double[] data, int index, int length)
        {
            double[] result = new double[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
