namespace AoC2023.Day1;

public class Day1
{
	public static void Solve()
	{
		var input = System.IO.File.ReadAllText("../../../Day1/Day1.txt")
			.Split('\n');


		var converted = input.Select(line =>
		{
			line = line.Replace("one", "on1ne");	
			line = line.Replace("two", "tw2wo");	
			line = line.Replace("three", "th3ree");
			line = line.Replace("four", "fo4ur");
			line = line.Replace("five", "fi5ve");
			line = line.Replace("six", "si6ix");
			line = line.Replace("seven", "se7en");
			line = line.Replace("eight", "ei8ht");
			line = line.Replace("nine", "ni9ne");
			line = line.Replace("zero", "ze0ero");

			return line;
		});
		
		var part1 = converted.Select(line =>
		{
			var firstDigit = -1;
			var lastDigit = -1;
			
			// Iterate over each character in the line
			foreach (char c in line)
			{
				if (char.IsDigit(c))
				{
					if (firstDigit == -1)
						firstDigit = c - '0';
					
					lastDigit = c - '0';
				}
			}

			Console.WriteLine(firstDigit + " " + lastDigit);
			return firstDigit * 10 + lastDigit;
		}).Sum();
		
		Console.Write(part1);
	}	
}