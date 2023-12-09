using System.Text;

namespace AoC2023.Day6;

public class Day6
{
	public static void Solve()
	{
		var input = System.IO.File.ReadAllText("../../../Day6/Day6Test.txt")
			.Split("\r\n");
		
		// var time = input.First().Split(':')[1].Split(" ").Select(s => s.Trim()).Select(int.Parse).ToList();
		// var dist = input.Skip(1).First().Split(':')[1].Split(" ").Select(s => s.Trim()).Select(int.Parse).ToList();
        
		// var time = new List<int>(){7, 15, 30};
		// var dist = new List<int>() {9, 40, 200};

        // Part 1
		//var time = new List<int>() {61, 67, 75, 71};
		//var dist = new List<int>() {430, 1036, 1307, 1150};
		
		// var time = new List<int>(){71530};
		// var dist = new List<int>(){940200};
		
		var time = new List<long>() {61677571};
		var dist = new List<long>() {430103613071150};

		var part1 = 1;
		for (var race = 0; race < time.Count; race++)
		{
			var wins = 0;
			for (var x = 0.0d; x < time[race]; x++)
			{
				var value = -Math.Pow(x, 2) + time[race]*x - dist[race];
				//Console.WriteLine($"Race {race}: {x} -> {value}");
				if (value > 0)
				{
					wins++;
				}	
			}
			
			part1 *= wins;
		}
		

		Console.WriteLine($"Part1: {part1}");
	}
}