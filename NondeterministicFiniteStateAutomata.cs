using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class NondeterministicFiniteStateAutomata
    {
        private const char Closure = '*';
        private const char LeftParenthesis = '(';
        private const char Or = '|';
        private const char RightParenthesis = ')';
        private const char Wildcard = '.';

        private readonly Digraph<int> epsilonTransitions;
        private readonly char[] regularExpression;

        public NondeterministicFiniteStateAutomata(string regularExpression)
        {
            this.regularExpression = regularExpression.ToCharArray();
            epsilonTransitions = new Digraph<int>(regularExpression.Length);
            var operators = new Stack<int>();
            for (var i = 0; i < regularExpression.Length; i++)
            {
                switch (this.regularExpression[i])
                {
                    case Closure:
                        epsilonTransitions.AddEdge(i, i + 1);
                        if (this.regularExpression[i - 1] != RightParenthesis)
                        {
                            epsilonTransitions.AddEdge(i - 1, i);
                            epsilonTransitions.AddEdge(i, i - 1);
                        }
                        break;
                    case LeftParenthesis:
                        epsilonTransitions.AddEdge(i, i + 1);
                        operators.Push(i);
                        break;
                    case Or:
                        operators.Push(i);
                        break;
                    case RightParenthesis:
                        epsilonTransitions.AddEdge(i, i + 1);
                        var leftParenthesis = operators.Pop();
                        if (leftParenthesis == Or)
                        {
                            var or = leftParenthesis;
                            leftParenthesis = operators.Pop();
                            epsilonTransitions.AddEdge(or, i);
                            epsilonTransitions.AddEdge(leftParenthesis, i + 1);
                        }

                        if (i < this.regularExpression.Length - 1 && regularExpression[i + 1] == Closure)
                        {
                            epsilonTransitions.AddEdge(leftParenthesis, i + 1);
                            epsilonTransitions.AddEdge(i + 1, leftParenthesis);
                        }   
                        break;
                    default:
                        break;
                }
            }
        }

        public bool Recognize(string text)
        {
            var dfs = new DirectedDfs<int>(epsilonTransitions, 0);
            IEnumerable<int> states = epsilonTransitions.Vertices.Where(dfs.IsMarked);
            foreach (var character in text)
            {
                var match = states.Where(s => s < regularExpression.Length && (regularExpression[s] == character || regularExpression[s] == Wildcard));
                dfs = new DirectedDfs<int>(epsilonTransitions, match);
                states = epsilonTransitions.Vertices.Where(dfs.IsMarked);
            }

            return states.Contains(regularExpression.Length);
        }
    }
}