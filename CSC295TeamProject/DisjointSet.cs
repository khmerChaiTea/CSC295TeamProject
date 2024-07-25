using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC295TeamProject
{
    public class DisjointSet
    {
        private int[] parent;   // Array to store parent of each element
        private int[] rank;     // Array to store rank (or depth) of trees

        public DisjointSet(int size)
        {
            parent = new int[size];   // Initialize parent array
            rank = new int[size];     // Initialize rank array

            // Initialize each element to be its own parent and rank to 0
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);    // Path compression: set parent to root
            }
            return parent[x];   // Return the root of the set containing x
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);    // Find root of x
            int rootY = Find(y);    // Find root of y

            if (rootX != rootY)     // If x and y are not already in the same set
            {
                if (rank[rootX] > rank[rootY])
                {
                    parent[rootY] = rootX;   // Attach smaller tree (rootY) under rootX
                }
                else if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;   // Attach smaller tree (rootX) under rootY
                }
                else
                {
                    parent[rootY] = rootX;   // Attach rootY under rootX (arbitrary choice)
                    rank[rootX]++;          // Increase rank of rootX
                }
            }
        }
    }
}
