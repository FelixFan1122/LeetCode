using System;

public abstract class EditDistance
{
    protected readonly int[,] distances;
    protected readonly string pattern;
    protected readonly string text;
    public EditDistance(string pattern, string text)
    {
        if (pattern == null)
        {
            throw new ArgumentNullException(nameof(pattern));
        }

        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }

        this.pattern = pattern;
        this.text = text;
        distances = new int[pattern.Length + 1, text.Length + 1];
    }

    public int GetEditDistance()
    {
        for (var i = 0; i < distances.GetLength(1); i++)
        {
            InitializeRow(i);
        }

        for (var i = 0; i < distances.GetLength(0); i++)
        {
            InitializeColumn(i);
        }

        for (var i = 1; i < distances.GetLength(0); i++)
        {
            for (var j = 1; j < distances.GetLength(1); j++)
            {
                var match = distances[i - 1, j - 1] + GetMatchCost(pattern[i - 1], text[j - 1]);
                var insert = distances[i, j - 1] + GetInsertDeleteCost(text[j -1]);
                var delete = distances[i - 1, j] + GetInsertDeleteCost(pattern[i - 1]);

                distances[i, j] = Math.Min(Math.Min(match, insert), delete);
            }
        }

        var goalCell = GetGoalCell();
        
        return distances[goalCell.Item1, goalCell.Item2];
    }

    protected abstract Tuple<int, int> GetGoalCell();

    protected abstract int GetInsertDeleteCost(char character);

    protected abstract int GetMatchCost(char patternCharacter, char textCharacter);

    protected abstract void InitializeColumn(int index);

    protected abstract void InitializeRow(int index);
}