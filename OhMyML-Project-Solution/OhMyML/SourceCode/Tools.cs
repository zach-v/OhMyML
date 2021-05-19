using System;
using System.Collections.Generic;

namespace OhMyML.SourceCode
{
    public static class Tools
    {
	    public static IEnumerable<T> ToEnumerable<T>(this Array target)
	    {
		    foreach (var item in target)
			    yield return (T)item;
	    }
    }
}
