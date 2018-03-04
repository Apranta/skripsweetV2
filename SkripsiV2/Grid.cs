//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System;

namespace SkripsiV2
{
	public class Grid
	{

		private char[][] matrix;
		private int maxRows;
		private int maxColumns;

		public Grid(int maxRows, int maxColumns)
		{
			this.maxRows = maxRows;
			this.maxColumns = maxColumns;

//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: matrix = new char[maxRows][maxColumns];
			matrix = RectangularArrays.ReturnRectangularCharArray(maxRows, maxColumns);

			initialize();
		}

		public virtual void setValue(int row, int column, char val)
		{

			if (row >= maxRows | column >= maxColumns | row < 0 | column < 0)
			{
				return;
			}

			matrix[row][column] = val;
		}

		public virtual char getValue(int row, int column)
		{

            if (row >= maxRows | column >= maxColumns | row < 0 | column < 0)
            {
                return (char)0;
            }

            return matrix[row][column];
		}

		public virtual int MaxRows
		{
			get
			{
				return maxRows;
			}
		}

		public virtual int MaxColumns
		{
			get
			{
				return maxColumns;
			}
		}

		public virtual void initialize()
		{

			for (int i = 0; i < maxRows; i++)
			{
				for (int j = 0; j < maxColumns; j++)
				{
					matrix[i][j] = ' ';
				}
			}
		}

		public virtual void show()
		{

			for (int j = 0; j < maxColumns; j++)
			{
				Console.Write("\t" + j);
			}

			Console.WriteLine();

			for (int i = 0; i < maxRows; i++)
			{
				Console.Write(i + "\t");

				for (int j = 0; j < maxColumns; j++)
				{
					Console.Write((matrix[i][j] == ' ' ? '-' : matrix[i][j]) + "\t");
				}

				Console.WriteLine();
			}
		}

        //public string[,] getAll()
        //{
        //    string[,] data = new string[maxRows, maxColumns];
        //    for (int i = 0; i < maxRows; i++)
        //    {
        //        for (int j = 0; j < maxColumns; j++)
        //        {
        //            data[i,j] = (string)matrix[i][j];
        //        }
        //    }
        //}
	}

}