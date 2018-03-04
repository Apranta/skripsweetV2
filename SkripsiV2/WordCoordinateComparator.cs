//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System.Collections.Generic;

namespace SkripsiV2
{

	public class WordCoordinateComparator : IComparer<WordCoordinate>
	{

		public virtual int Compare(WordCoordinate o1, WordCoordinate o2)
		{
			return o2.Score - o1.Score;
		}
	}

}