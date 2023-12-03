namespace AoC2023.Day3;

public class Day3
{
	public static void Solve()
	{
		var input = System.IO.File.ReadAllText("../../../Day3/Day3.txt")
			.Split('\n')
			.Select(line => line.ToCharArray())
			.ToArray();

		var h = input.Length;
		var w = input[0].Length - 1;
		
		var part1 = 0;
		var part2 = 0;
		// Iterate over each character in the line
		for (var y = 0; y < h; y++)
		{
			var numberTemp = 0;
			var numberHasSymbol = false;
			for (var x = 0; x < w; x++)
			{
				// GEARCODE
				if (input[y][x] == '*')
				{
					var adjacentNumbers = findAdjacentNumbers(input, h, w, x, y);
					if (adjacentNumbers.Count == 2)
					{
						// Get first two numbers in hashset
						var an = adjacentNumbers.ToList();
						part2 += an[0] * an[1];
					}
				}
				
				// Nothing/Or Symbol
				if (!char.IsDigit(input[y][x]))
				{
					if (numberHasSymbol && numberTemp != 0)
					{
						part1 += numberTemp;
					}
					
					numberTemp = 0;
					numberHasSymbol = false;
					continue;
				}

				// Is number
				var digit = input[y][x] - '0';
				numberTemp = numberTemp * 10 + digit;

				if (hasAdjacentSymbol(input, h, w, x, y))
				{
					numberHasSymbol = true;
				}
			}
			
			// Stupid
			if (numberHasSymbol && numberTemp != 0)
			{
				part1 += numberTemp;
				Console.WriteLine("Extracted number: " + numberTemp);
			}
		}
		
		Console.WriteLine($"Part 1: {part1}");
		Console.WriteLine($"Part 2: {part2}");
	}

	private static bool hasAdjacentSymbol(char[][] grid, int h, int w, int x, int y)
	{
		var hasAdjacent = false;
		for (var i = -1; i <= 1; i++)
		{
			for (var j = -1; j <= 1; j++)
			{
				if (i == 0 && j == 0)
					continue;

				var newX = x + i;
				var newY = y + j;

				if (newX < 0 || newX >= w || newY < 0 || newY >= h)
					continue;

				if (grid[newY][newX] != '.' && !char.IsDigit(grid[newY][newX]))
				{
					hasAdjacent = true;
					break;
				}
			}
		}

		return hasAdjacent;
	}
	
	private static HashSet<int> findAdjacentNumbers(char[][] grid, int h, int w, int x, int y)
	{
		var adjacentNumbers = new HashSet<int>();
		
		for (var i = -1; i <= 1; i++)
		{
			for (var j = -1; j <= 1; j++)
			{
				if (i == 0 && j == 0)
					continue;

				var newX = x + i;
				var newY = y + j;

				if (newX < 0 || newX >= w || newY < 0 || newY >= h)
					continue;

				if (char.IsDigit(grid[newY][newX]))
				{
					// Find left-most digit
					var leftMostX = newX;
					while (leftMostX > 0 && char.IsDigit(grid[newY][leftMostX - 1]))
					{
						leftMostX--;
					}
					
					// Get number
					var number = 0;
					while (leftMostX < w && char.IsDigit(grid[newY][leftMostX]))
					{
						var digit = grid[newY][leftMostX] - '0';
						number = number * 10 + digit;
						leftMostX++;
					}
					
					// REALLY HOPING THIS DOESN'T CAUSE ANY PROBLEMS
					adjacentNumbers.Add(number);
				}
			}
		}

		return adjacentNumbers;
	}
}