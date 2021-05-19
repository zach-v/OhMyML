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
}
