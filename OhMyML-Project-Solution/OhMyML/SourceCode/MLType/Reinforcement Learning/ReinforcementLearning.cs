using System;
namespace OhMyML.SourceCode.MLType
{
    public class ReinforcementLearning<I, L, O> : MLTypeInterface<I, L, O>
    {
        public ReinforcementLearning()
        {
        }

		public O GetOutput()
		{
			throw new NotImplementedException();
		}

		public void SetInput(I input)
		{
			throw new NotImplementedException();
		}
	}
}
