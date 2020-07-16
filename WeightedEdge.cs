using System;

namespace LeetCode
{
    public class WeightedEdge<TVertex, TWeight> : IComparable<WeightedEdge<TVertex, TWeight>> where TWeight : IComparable<TWeight>
    {
        private readonly TVertex vertex1;
        private readonly TVertex vertex2;

        public WeightedEdge(TVertex vertex1, TVertex vertex2, TWeight weight)
            : this(vertex1, vertex2, weight, default(TVertex)) {}

        public WeightedEdge(TVertex vertex1, TVertex vertex2, TWeight weight, TVertex id)
        {
            Id = id;
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            Weight = weight;
        }

        public TVertex Id { get; private set; }

        public TWeight Weight { get; private set; }

        public int CompareTo(WeightedEdge<TVertex, TWeight> other) => Weight.CompareTo(other.Weight);

        public TVertex GetTheOtherVertex(TVertex vertex)
        {
            if (vertex.Equals(vertex1))
            {
                return vertex2;
            }
            else
            {
                return vertex1;
            }
        }

        public TVertex GetVertex() => vertex1;
    }
}