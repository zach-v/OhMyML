using System;
using System.Collections.Generic;

namespace OhMyML.SourceCode.MLType.DeepLearning
{
    public class DeepLearning<T>
    {
        public List<Layer<Node<T>>> Layers { get; set; }
        public DeepLearning()
        {
        }

	}
}
