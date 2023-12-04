namespace AoC2023.Day4;

public class Day4
{
	public static void Solve()
	{
		var input = System.IO.File.ReadAllText("../../../Day4/Day4.txt")
			.Split('\n')
			.Select(s => s.Replace("  ", " "))
			.ToList();

		var copies = Enumerable.Repeat(1, input.Count).ToList();
		
		var part1 = 0;
		var card = 0;
		foreach (var line in input)
		{
			
			var contents = line.Split(": ")[1].Split(" | ");

			var winningNum = contents[0].Split(" ")
				.Select(int.Parse)
				.ToList();
			
			var num = contents[1].Split(" ")
				.Select(int.Parse)
				.ToList();

			var points = num
				.Select(n => winningNum.Contains(n) ? 1 : 0)
				.Sum();
			
			var power = (int) Math.Pow(2, points - 1);
			part1 += power;

			for (int i = 1; i <= points; i++)
			{
				copies[card + i] += copies[card];
			}

			card++;
		}

		Console.WriteLine($"Part1: {part1}");
		Console.WriteLine($"Part2: {copies.Sum()}");
		
	}
}