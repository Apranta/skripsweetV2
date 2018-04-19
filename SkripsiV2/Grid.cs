﻿using System;

namespace SkripsiV2
{
	public class Grid
	{

		private char[][] matrix;
		private int maxRows;
		private int maxColumns;
        public String[,] data;
        public Grid(int maxRows, int maxColumns)
		{
			this.maxRows = maxRows;
			this.maxColumns = maxColumns;
            
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

        public String[,] getA()
        {
            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxColumns; j++)
                {
                    Console.Write((matrix[i][j] == ' ' ? '-' : matrix[i][j]) + "\t");
                }
            }

            return data;
        }
    }

}