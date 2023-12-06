using System.Reflection;

namespace AoC2023.Day5;

public class Day5
{
	private record Mapping(long DestRangeStart, long SrcRangeStart, long Length);

	private record ThingMap(string Source, string Destination, List<Mapping> Map, Dictionary<long, long> Dict);
		
	public static void Solve()
	{
		// Parsing
		var input = System.IO.File.ReadAllText("../../../Day5/Day5.txt")
			.Split("\r\n\r\n");

		var seeds = input.First().Split(" ").Skip(1).Select(long.Parse).ToList();

		var maps = input.Skip(1)
			.Select(m =>
			{
				var i = m.Split("\r\n");
				var mapNames = i.First().Split("-");
				mapNames[2] = mapNames[2].Split(" ")[0];

				var map = i.Skip(1).Select(l =>
				{
					var split = l.Split(" ").Select(long.Parse).ToArray();
					return new Mapping(split[0], split[1], split[2]);
				}).ToList();

				var dict = new Dictionary<long, long>();

				return new ThingMap(mapNames[0], mapNames[2], map, dict);
			})
			.ToDictionary(t => t.Source, t => t);
		
		// Part 1
		var seedLocations = new List<long>();
		foreach (var seed in seeds)
		{
			var result = seed;
			var resultType = "seed";
			while (resultType != "location")
			{
				var map = maps[resultType];
				
				foreach (var mapping in map.Map)
				{
					var temp = result;
					if (result >= mapping.SrcRangeStart && result < mapping.SrcRangeStart + mapping.Length)
					{
						result = mapping.DestRangeStart + (result - mapping.SrcRangeStart);
						break;
					}
					
					if (seed == 55)
						Console.WriteLine($"{seed}: {temp} -> {result}");
				}
				
				//Console.WriteLine($"Going from {resultType} to {map.Destination}");
				resultType = map.Destination;
			}
 
			if (seed == 55)
				Console.WriteLine($"{seed} -> {result}");
			seedLocations.Add(result);
		}
		
		// Part 2
		// var minimum = long.MaxValue;
		// for (var seedIndex = 0; seedIndex < seeds.Count; seedIndex += 2)
		// {
		// 	var initialSeed = seeds[seedIndex];
		// 	for (var i = 0; i < seeds[seedIndex + 1]; i++)
		// 	{
		// 		var result = seeds[seedIndex] + i;
		// 		var resultType = "seed";
		// 		while (resultType != "location")
		// 		{
		// 			var map = maps[resultType];
		// 			
		// 			foreach (var mapping in map.Map)
		// 			{
		// 				if (result >= mapping.SrcRangeStart && result < mapping.SrcRangeStart + mapping.Length)
		// 				{
		// 					result = mapping.DestRangeStart + (result - mapping.SrcRangeStart);
		// 					break;
		// 				}
		// 			}
		// 			
		// 			resultType = map.Destination;
		// 		}
		// 		
		// 		if (result < minimum)
		// 		{
		// 			minimum = result;
		// 		}
		// 	}
		// 	
		// 	Console.WriteLine("yo");
		// 	
		// }
		
		// Part 2 Attempt 2
		//var minimum = long.MaxValue;
		// var seedsToFind = 0l;
		// for (var seedIndex = 0; seedIndex < seeds.Count; seedIndex += 2)
		// {
		// 	var initialSeed = seeds[seedIndex];
		// 	var numberOfSeeds = seeds[seedIndex + 1];
		// 	
		// 	var result = initialSeed;
		// 	
		// }
		
		// Part 2 Attempt 3
		long part2 = 0; //120000000;
		while (true)
		{
			var resultType = "humidity";
			var result = part2;
			
			while (resultType != "done")
			{
				var map = maps[resultType];

				var temp = result;
				foreach (var mapping in map.Map)
				{
					if (result >= mapping.DestRangeStart && result < mapping.DestRangeStart + mapping.Length)
					{
						result = mapping.SrcRangeStart + (result - mapping.DestRangeStart);
						break;
					}
				}
				
				if (part2 == 86)
					Console.WriteLine($"{part2}: {temp} -> {result}");

				//resultType = map.Source; // Assume you have a corresponding property to get the source
				if (resultType == "seed") break;
				
				resultType = maps.First(m => m.Value.Destination == map.Source).Value.Source;
			}
			
			// Check if result is a seed
			for (var seedIndex = 0; seedIndex < seeds.Count; seedIndex += 2)
			{
				var initialSeed = seeds[seedIndex];
				var numberOfSeeds = seeds[seedIndex + 1];
				
				if (result >= initialSeed && result <= initialSeed + numberOfSeeds)
				{
					Console.WriteLine($"Found seed {result} at {part2}");
					Console.WriteLine($"Found seed {result} at {part2}");
					Console.WriteLine($"Found seed {result} at {part2}");
					Console.WriteLine($"Found seed {result} at {part2}");
					goto WriteAnswers;
				}
			}

			if (part2 % 10000000 == 0)
				Console.WriteLine($"Passed {part2}");
			
			part2++;
		}
		
		// Part 2 attempt 4
		// var
		
		//Console.WriteLine(seedsToFind);
		
		WriteAnswers:
		Console.WriteLine($"Part 1: {seedLocations.Min()}");
		Console.WriteLine($"Part 2: {part2}");
	}
}

// 55: 55 -> 55
// 55: 57 -> 57       
// 55: 57 -> 57       
// 55: 57 -> 57       
// 55: 53 -> 53       
// 55: 46 -> 46       
// 55: 82 -> 82       
// 55: 82 -> 82    
// 	
// 86: 86 -> 82
// 86: 82 -> 82
// 86: 82 -> 46
// 86: 46 -> 53
// 86: 53 -> 57
// 86: 57 -> 57
