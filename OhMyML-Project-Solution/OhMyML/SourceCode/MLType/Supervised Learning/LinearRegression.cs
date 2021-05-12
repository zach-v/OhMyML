using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace OhMyML.SourceCode.MLType.SupervisedLearning
{
    public abstract class Regressor<I, O>
	{
        public abstract void Fit(I x, I y);
        public abstract O Predict(I x);
	}
    /// <summary>
    /// Simple Linear Regression implementation
    /// Performs linear regression on one feature and on output value
    /// </summary>
    public class LinearRegressor : Regressor<float[], float[]>
    {
        private float _b0;
        private float _b1;

        public LinearRegressor()
        {
            _b0 = 0;
            _b1 = 1;
        }

        public override void Fit(float[] X, float[] y)
        {
            float ssxy = X.Zip(y, (a, b) => a * b).Sum() - X.Length * X.Average() * y.Average();
            float ssxx = X.Zip(X, (a, b) => a * b).Sum() - X.Length * X.Average() * X.Average();

            _b1 = ssxy / ssxx;
            _b0 = y.Average() - _b1 * X.Average();
        }

        public override float[] Predict(float[] x)
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

        public override void Fit(double[,] X, double[,] y)
        {
            Matrix<double> input = ExtendInputWithOnes(X);
            Matrix<double> output = Matrix<double>.Build.DenseOfArray(y);

            Vector<double> coefficients = ((input.Transpose() * input).Inverse() * input.Transpose() * output)
                                .Transpose().Row(0);

            _b = coefficients.ElementAt(0);
            _w = SubArray(coefficients.ToArray(), 1, X.GetLength(1));
        }

        public override double Predict(double[,] x)
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
