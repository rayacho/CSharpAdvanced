﻿using System;
using System.Text.RegularExpressions;

namespace _2._4._Treasure_Map
{
	class Program
	{
		static void Main(string[] args)
		{
			string pattern = @"((?<hash>#)|!)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?(?(hash)!|#)";

			int count = int.Parse(Console.ReadLine());

			for (int i = 0; i < count; i++)
			{
				string input = Console.ReadLine();

				MatchCollection matches = Regex.Matches(input, pattern);

				Match correctMatch = matches[matches.Count / 2];

				string streetName = correctMatch.Groups["streetName"].Value;
				string streetNumber = correctMatch.Groups["streetNumber"].Value;
				string password = correctMatch.Groups["password"].Value;

				Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
			}
		}
	}
}
