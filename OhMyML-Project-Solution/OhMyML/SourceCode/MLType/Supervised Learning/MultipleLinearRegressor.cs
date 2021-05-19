using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace OhMyML.SourceCode.MLType.Supervised_Learning
{
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
