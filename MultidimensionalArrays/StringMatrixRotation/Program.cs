﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringMatrixRotation
{
	class Program
	{
		public static void Main()
		{
			int degrees = GetRotationDegrees();
			char[][] matrix = GetMatrix();

			switch (degrees)
			{
				case 0: PrintMatrix(matrix); break;
				case 90: PrintMatrix90(matrix); break;
				case 180: PrintMatrix180(matrix); break;
				case 270: PrintMatrix270(matrix); break;
			}
		}

		private static void PrintMatrix270(char[][] matrix)
		{
			for (int c = matrix[0].Length - 1; c >= 0; c--)
			{
				for (int r = 0; r < matrix.Length; r++)
				{
					Console.Write(matrix[r][c]);
				}
				Console.WriteLine();
			}
		}

		private static void PrintMatrix90(char[][] matrix)
		{
			for (int c = 0; c < matrix[0].Length; c++)
			{
				for (int r = matrix.Length - 1; r >= 0; r--)
				{
					Console.Write(matrix[r][c]);
				}
				Console.WriteLine();
			}
		}

		private static void PrintMatrix180(char[][] matrix)
		{
			for (int r = matrix.Length - 1; r >= 0; r--)
			{
				Console.WriteLine(string.Join("", matrix[r].Reverse()));
			}
		}

		private static void PrintMatrix(char[][] matrix)
		{
			foreach (char[] row in matrix)
			{
				Console.WriteLine(string.Join("", row));
			}
		}

		private static char[][] GetMatrix()
		{
			List<string> textList = new List<string>();

			while (true)
			{
				string text = Console.ReadLine();
				if (text == "END") break;
				textList.Add(text);
			}

			int rows = textList.Count();
			int cols = textList.Select(x => x.Count()).Max();
			char[][] matrix = new char[rows][];

			for (int row = 0; row < rows; row++)
			{
				StringBuilder builder = new StringBuilder(textList[row]);
				builder.Append(new String(' ', cols - textList[row].Length));
				matrix[row] = builder.ToString().ToCharArray();
			}
			return matrix;
		}

		private static int GetRotationDegrees()
		{
			string input = Console.ReadLine().Trim();
			int degrees = int.Parse(input.Substring("Rotate(".Length, input.Length - 1 - "Rotate(".Length));
			degrees %= 360;

			while (degrees < 0)
			{
				degrees += 360;
			}

			return degrees;
		}
	}
}
