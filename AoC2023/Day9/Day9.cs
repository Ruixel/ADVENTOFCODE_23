namespace AoC2023.Day9;

public class Day9
{
	public static void Solve()
	{
		var input = System.IO.File.ReadAllText("../../../Day9/Day9.txt")
			.Split("\r\n")
			.Select(l => l.Split().Select(int.Parse).ToList())
			.ToList();

		var part1 = 0;
		var part2 = 0;
		foreach (var seq in input)
		{
			var seqs = new List<List<int>>();
			seqs.Add(seq);

			var seqIndex = 0;
			var isLinear = false;
			while (!isLinear)
			{
				var diffs = seqs[seqIndex].Skip(1).Select((i, idx) => i - seqs[seqIndex][idx]).ToList();
				seqs.Add(diffs);
				
				isLinear = diffs.All(d => d == 0);
				seqIndex++;
			}
			
			Console.WriteLine($"Found linear sequence of length {seqs.Count} at index {seqIndex}");
			
			// Find the next number
			seqIndex--;
			while (seqIndex >= 0)
			{
				var next = seqs[seqIndex].Last() + seqs[seqIndex + 1].Last();
				seqs[seqIndex].Add(next);
				
				seqIndex--;
			}
			
			// Find the previous number
			seqIndex = seqs.Count - 2;
			while (seqIndex >= 0)
			{
				var prev = seqs[seqIndex].First() - seqs[seqIndex + 1].First();
				seqs[seqIndex].Insert(0, prev);
				
				seqIndex--;
			}


			part1 += seqs[0].Last();
			part2 += seqs[0].First();
		}

		Console.WriteLine($"Part1: {part1}");
		Console.WriteLine($"Part2: {part2}");
		
	}
}