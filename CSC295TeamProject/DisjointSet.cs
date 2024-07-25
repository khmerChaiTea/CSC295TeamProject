using System;

namespace CSC295TeamProject
{
    /// <summary>
    /// Implementation of Disjoint Set (Union-Find) data structure with path compression and union by rank.
    /// </summary>
    public class DisjointSet
    {
        private int[] parent;   // Array to store parent of each element
        private int[] rank;     // Array to store rank (or depth) of trees

        /// <summary>
        /// Initializes a new instance of the DisjointSet class with the specified size.
        /// </summary>
        /// <param name="size">The number of elements in the DisjointSet.</param>
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

        /// <summary>
        /// Finds the root of the set containing the element x with path compression.
        /// </summary>
        /// <param name="x">The element to find.</param>
        /// <returns>The root of the set containing x.</returns>
        public int Find(int x)
        {
            if (parent[x] != x)
            {
                // Path compression: Set the parent of x to the root of its set
                parent[x] = Find(parent[x]);
            }
            return parent[x];   // Return the root of the set containing x
        }

        /// <summary>
        /// Unites the sets that contain x and y into a single set.
        /// </summary>
        /// <param name="x">The first element.</param>
        /// <param name="y">The second element.</param>
        public void Union(int x, int y)
        {
            int rootX = Find(x);    // Find root of x
            int rootY = Find(y);    // Find root of y

            // If x and y are not already in the same set
            if (rootX != rootY)
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

        /// <summary>
        /// Checks if two elements x and y are connected, i.e., if they belong to the same set.
        /// </summary>
        /// <param name="x">The first element.</param>
        /// <param name="y">The second element.</param>
        /// <returns>True if x and y are in the same set, false otherwise.</returns>
        public bool Connected(int x, int y)
        {
            return Find(x) == Find(y);
        }

        /// <summary>
        /// Prints the current sets represented by their roots.
        /// </summary>
        public void PrintSets()
        {
            Console.WriteLine("Current sets:");
            for (int i = 0; i < parent.Length; i++)
            {
                Console.WriteLine($"Element {i}: Root = {Find(i)}");
            }
            Console.WriteLine();
        }
    }
}

