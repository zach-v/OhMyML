using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhMyML.SourceCode.MLType.Supervised_Learning
{
    public interface IRegressor { }
    public abstract class Regressor<I> : IRegressor
    {
        public abstract void Fit(I x, I y);
        public abstract I Predict(I x);
    }
    public abstract class Regressor<I, O> : IRegressor
    {
        public abstract void Fit(I x, I y);
        public abstract O Predict(I x);
    }
}
