using System;
using System.Collections.Generic;

public class Topological<T>
{
    public Topological(Digraph<T> digraph)
    {
        if (digraph == null)
        {
            throw new ArgumentNullException(nameof(digraph));
        }

        if (!new DirectedCycle<T>(digraph).HasCycle)
        {
            Order = new DepthFirstOrder<T>(digraph).ReversePostOrder;
        }
    }

    public IEnumerable<T> Order { get; private set; }
}