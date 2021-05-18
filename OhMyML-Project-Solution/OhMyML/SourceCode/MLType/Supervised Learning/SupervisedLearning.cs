using System;
using System.Collections.Generic;
using System.Linq;
using OhMyML.SourceCode.MLType.SupervisedLearning;

namespace OhMyML.SourceCode.MLType.Supervised_Learning
{
	public class SupervisedLearning<I, L, O> : MLTypeInterface<OhMath.DimensionalHolder<I>, L, IEnumerable<O>> where L : IRegressor
	{
		private LinearRegressor linearRegressor;
		private MultipleLinearRegressor multipleRegressor;
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

		private void MultipleLinearRegression(OhMath.DimensionalHolder<I> input)
		{
			multipleRegressor = new MultipleLinearRegressor();

			// We assume the same thing of having 2 inputs
			if (input.items.Count >= 1)
				multipleRegressor.Fit(input.items[0].OfType<double[,]>(), input.items[1].OfType<double[,]>());
		}
		public void SetInput(OhMath.DimensionalHolder<I> input)
		{
			if (typeof(L) == typeof(LinearRegressor))
				SingleLinearRegression(input);
		}

		public O GetOutput(IEnumerable<O> input)
		{
			if (typeof(L) == typeof(LinearRegressor))
				if(typeof(O).IsAssignableFrom(typeof(IEnumerable<O>)))
					return (O)Convert.ChangeType(SingleLinearRegressionPredict(input), typeof(IEnumerable<O>));
			return default;
		}
	}
}
