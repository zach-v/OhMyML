using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhMyML.SourceCode.MLType.Supervised_Learning
{
    public interface IClassify {}
    public interface Classify<I> : IClassify
    {
        public void Train(I x, I y);
        public I Evaluate(I x);
        public I Save(I x);
    }
    public interface Classify<I, O> : IClassify
    {
        public void Train(I x, I y);
        public O Evaluate(I x);
        public O Save(I x);
    }
}
