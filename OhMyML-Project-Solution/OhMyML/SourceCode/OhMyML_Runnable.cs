using OhMyML.SourceCode;
using OhMyML.SourceCode.MLType.SupervisedLearning;
using System;
using System.Collections.Generic;

namespace OhMyML
{
	class OhMyML_Runnable
	{
		static void Main(string[] args)
		{
			SupervisedLearning<string, LinearRegressor, double> sl;
			sl = new SupervisedLearning<string, LinearRegressor, double>();
		}
	}
}
