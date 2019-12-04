using System;

public class LevenshteinDistance : EditDistance
{
    public LevenshteinDistance(string pattern, string text)
        : base(pattern, text)
    {

    }

    protected override Tuple<int, int> GetGoalCell()
    {
        return new Tuple<int, int>(pattern.Length, text.Length);
    }

    protected override int GetInsertDeleteCost(char character)
    {
        return 1;
    }

    protected override int GetMatchCost(char patternCharacter, char textCharacter)
    {
        return patternCharacter == textCharacter ? 0 : 1;
    }

    protected override void InitializeColumn(int index)
    {
        distances[index, 0] = index;
    }

    protected override void InitializeRow(int index)
    {
        distances[0, index] = index;
    }
}