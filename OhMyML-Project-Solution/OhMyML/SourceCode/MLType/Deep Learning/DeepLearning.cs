using System;
namespace OhMyML.SourceCode.MLType.DeepLearning
{
    public class DeepLearning<L> : MLTypeInterface<double[], L, double[]>
    {
        public DeepLearning()
        {
        }

		public double[] GetOutput()
		{
			throw new NotImplementedException();
		}

		public void SetInput(double[] input)
		{
			throw new NotImplementedException();
		}
	}
}
