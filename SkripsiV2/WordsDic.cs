//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System.Collections.Generic;
using System.IO;

namespace SkripsiV2
{

	public class WordsDic
	{

		private Dictionary<string, string> dictionary;

		public WordsDic()
		{

			dictionary = new Dictionary<string, string>();

			try
			{

				readDictionary();

			}
			catch (IOException)
			{

				dictionary = new Dictionary<string, string>();
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void readDictionary() throws java.io.IOException
		private void readDictionary()
		{

			string fileName = "D:/dictionary1.txt";
			System.IO.StreamReader reader = new System.IO.StreamReader(fileName);
			string str;

			while (!string.ReferenceEquals((str = reader.ReadLine()), null))
			{

				string[] line = str.Split(";", true);

				dictionary[line[0].Trim()] = line[1].Trim();
			}
			reader.Close();
		}

		public virtual Dictionary<string, string> Dictionary
		{
			get
			{
				return dictionary;
			}
		}

	}

}