using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhMyML.SourceCode.MLType.Supervised_Learning
{
    public interface Regressor<I>
    {
        public void Fit(I x, I y);
        public I Predict(I x);
    }
    public interface Regressor<I, O>
    {
        public void Fit(I x, I y);
        public O Predict(I x);
    }
}
