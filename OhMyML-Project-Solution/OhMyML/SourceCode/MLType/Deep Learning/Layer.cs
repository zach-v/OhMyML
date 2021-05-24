using System;
using System.Collections.Generic;

namespace OhMyML.SourceCode.MLType.DeepLearning
{
    public class Layer<T>
    {
	    public List<Node<T>> NodeList { get; set; }
        public Layer()
        {
        }
    }
}
