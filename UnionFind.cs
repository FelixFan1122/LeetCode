using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class UnionFind<TComponent>
    {
        private Dictionary<TComponent, Component> forest;

        public UnionFind(IEnumerable<TComponent> components)
        {
            if (components == null)
            {
                throw new ArgumentNullException(nameof(components));
            }
            
            forest = new Dictionary<TComponent, Component>();
            foreach(var component in components)
            {
                forest.Add(component, new Component { Parent = component, Size = 1 });
                Count++;
            }
        }

        public int Count { get; private set; }

        public TComponent Find(TComponent component)
        {
            if (!forest.ContainsKey(component))
            {
                throw new ArgumentOutOfRangeException(nameof(component));
            }

            var path = new List<TComponent>();
            while (!forest[component].Parent.Equals(component))
            {
                path.Add(component);
                component = forest[component].Parent;
            }

            foreach (var child in path)
            {
                forest[child].Parent = component;
                forest[child].Size = 1;
            }

            return component;
        }

        public bool IsConnected(TComponent component1, TComponent component2) => Find(component1).Equals(Find(component2));

        public void Union(TComponent component1, TComponent component2)
        {
            component1 = Find(component1);
            component2 = Find(component2);
            if (!component1.Equals(component2))
            {
                Count--;
                if (forest[component1].Size < forest[component2].Size)
                {
                    forest[component1].Parent = component2;
                    forest[component2].Size += forest[component1].Size;
                }
                else
                {
                    forest[component2].Parent = component1;
                    forest[component1].Size += forest[component2].Size;
                }
            }
        }

        private class Component
        {
            public TComponent Parent;
            public int Size;
        }
    }
}