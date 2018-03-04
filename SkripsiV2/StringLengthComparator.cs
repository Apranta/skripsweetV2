//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System.Collections.Generic;

namespace SkripsiV2
{

	public class StringLengthComparator : IComparer<string>
	{

		public virtual int Compare(string s1, string s2)
		{
			return s2.Length - s1.Length;
		}
	}
}