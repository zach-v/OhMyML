﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhMyML.SourceCode.MLType
{
	public interface MLTypeInterface<in I, L, out O>
	{
		public void SetInput(I input);
		public O GetOutput();
	}
}