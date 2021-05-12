using System;
namespace OhMyML.SourceCode.MLType
{
    public class UnsupervisedLearning<I, L, O> : MLTypeInterface<I, L, O>
    {
        public UnsupervisedLearning()
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
