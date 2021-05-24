using System;
namespace OhMyML.SourceCode.MLType.DeepLearning
{
    public class Node<T>
    {
	    public T item { get; set; }
	    public float weight, bias;
        public Node()
        {
        }
    }
}
