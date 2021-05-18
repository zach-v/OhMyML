using OhMyML.SourceCode;
using OhMyML.SourceCode.MLType.SupervisedLearning;
using System;
using System.Collections.Generic;
using OhMyML.SourceCode.MLType.Supervised_Learning;

namespace OhMyML
{
	class OhMyML_Runnable
	{
		static void Main(string[] args)
		{
			float[] data = new float[] {3.4f, 29.43f};
			SupervisedLearning<float[], LinearRegressor, float[]> sl = new SupervisedLearning<float[], LinearRegressor, float[]>();
			sl.SetInput(data);
			float[] result = sl.GetOutput();

			foreach (float r in result)
			{
				Console.WriteLine($"Our result was: {r}\n");
			}
		}
	}
}
