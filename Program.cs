using System;
using System.IO;
using System.Linq;

class NamesScoreCalculator
{
    private string[] names;

    public NamesScoreCalculator()
    {
        names = File.ReadAllText("names.txt").Split(",").OrderBy(name => name).ToArray();

        for (int i = 0; i < names.Length; i++)
        {
            names[i] = names[i].Trim('"');
        }

    }

    public void CalculateTotalScore()
    {
        long total = 0;

        for (int i = 0; i < names.Length; i++)
        {
            char[] name = names[i].ToCharArray();

            total += CalculateNameScore(name, i);

        }

        Console.WriteLine(total);
    }

    public long CalculateNameScore(char[] name, int position)
    {
        long score = 0;
        for (int i = 0; i < name.Length; i++)
        {
            score += GetLetterValue(name[i]);
        }
        score *= position + 1;
        return score;
    }

    public int GetLetterValue(char letter)
    {
        int value = char.ToUpper(letter) - 64;

        return value;
    }


}

class Program
{
    static void Main(string[] args)
    {
        NamesScoreCalculator nameCalculator = new NamesScoreCalculator();
        nameCalculator.CalculateTotalScore();
    }
}


