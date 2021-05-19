using System;
using System.Collections;
using System.Collections.Generic;

namespace OhMyML.SourceCode
{
	public static class OhMath
	{
		public static double EuclideanDistance(double[] sampleOne, double[] sampleTwo)
		{
			double d = 0.0;

			for (int i = 0; i < sampleOne.Length; i++)
			{
				double temp = sampleOne[i] - sampleTwo[i];
				d += temp * temp;
			}

			return Math.Sqrt(d);
		}

		public static DimensionalHolder<T> CreateHolder<T>(params IEnumerable<T>[] input)
		{
			DimensionalHolder<T> sender = DimensionalHolder<T>.Default();

			foreach (IEnumerable<T> i in input)
			{
				try
				{
					sender.items.Add(i);
				}
				catch (InvalidCastException)
				{
					Console.WriteLine($"Invalid cast in Create Holder for type: {typeof(T).Name}");
				}
			}
			return sender;
		}
		public struct DimensionalHolder<T>
		{
			public List<IEnumerable<T>> items { get; set; }
			public DimensionalHolder(List<IEnumerable<T>> items)
			{
				this.items = items;
			}
			public static DimensionalHolder<T> Default()
			{
				return new DimensionalHolder<T>(new List<IEnumerable<T>>());
			}
		}
	}
}
