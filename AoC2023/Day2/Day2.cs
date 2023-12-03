using System.Text.RegularExpressions;

namespace AoC2023.Day2;

public class Day2
{
	public static void Solve()
	{
		var input = System.IO.File.ReadAllText("../../../Day2/Day2.txt")
			.Split('\n');

		var game = 1;
		var validGames = 0;
		var totalPower = 0;
		foreach (var line in input)
		{
			var split = line.Split(": ");
			var sets = split[1].Split("; ");

			var ok = true;
			var blueMax = 0;
			var redMax = 0;
			var greenMax = 0;

			foreach (var set in sets)
			{
				var blue = 0;
				var red = 0;
				var green = 0;
				
				var match = Regex.Match(set, @"(\d+) blue");
				if (match.Success)
				{
					blue = int.Parse(match.Groups[1].Value);
					if (blue > blueMax)
					{
						blueMax = blue;
					}
				}

				var matchRed = Regex.Match(set, @"(\d+) red");
				if (matchRed.Success)
				{
					red = int.Parse(matchRed.Groups[1].Value);
					if (red > redMax)
					{
						redMax = red;
					}
				}

				var matchGreen = Regex.Match(set, @"(\d+) green");
				if (matchGreen.Success)
				{
					green = int.Parse(matchGreen.Groups[1].Value);
					if (green > greenMax)
					{
						greenMax = green;
					}
				}

				if (red > 12 || green > 13 || blue > 14)
				{
					ok = false;
				}
			}

			if (ok)
			{
				validGames += game;
			}
			
			var power = redMax * greenMax * blueMax;
			totalPower += power;

			game++;
		}

		Console.WriteLine("Part 1: " + validGames);
		Console.WriteLine("Part 2: " + totalPower);
	}
}