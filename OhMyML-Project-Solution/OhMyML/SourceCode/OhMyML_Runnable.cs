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
			SupervisedLearning<float[], LinearRegressor, float[]> sl;
			sl = new SupervisedLearning<float[], LinearRegressor, float[]>();
		}
	}
}
