using System;
using System.Collections.Generic;

namespace CSC295TeamProject
{
    /// <summary>
    /// Main program demonstrating usage of DisjointSet and Kruskal's algorithm to find Minimum Spanning Tree (MST).
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Example usage of DisjointSet

            int size = 10;  // Size of the DisjointSet

            // Create a new DisjointSet with size 10
            DisjointSet ds = new DisjointSet(size);

            // Print initial sets
            Console.WriteLine("Initial sets:");
            ds.PrintSets();

            // Perform some union operations
            ds.Union(0, 1);
            ds.Union(2, 3);
            ds.Union(4, 5);
            ds.Union(6, 7);
            ds.Union(0, 2);

            // Print sets after initial unions
            Console.WriteLine("Sets after initial unions:");
            ds.PrintSets();

            // Find operations
            Console.WriteLine("Find(1): " + ds.Find(1)); // Should print the root of set containing 1
            Console.WriteLine("Find(3): " + ds.Find(3)); // Should print the root of set containing 3
            Console.WriteLine("Find(5): " + ds.Find(5)); // Should print the root of set containing 5
            Console.WriteLine();

            // Perform more union operations
            ds.Union(1, 3);
            ds.Union(4, 6);

            // Print sets after additional unions
            Console.WriteLine("Sets after additional unions:");
            ds.PrintSets();

            // Find operations after unions
            Console.WriteLine("Find(3): " + ds.Find(3)); // Should print the root of set containing 3
            Console.WriteLine("Find(5): " + ds.Find(5)); // Should print the root of set containing 5
            Console.WriteLine("Find(7): " + ds.Find(7)); // Should print the root of set containing 7
            Console.WriteLine();

            // Example usage of Kruskal's algorithm to find MST
            List<Edge> edges = new List<Edge>
            {
                new Edge(0, 1, 10),
                new Edge(0, 2, 6),
                new Edge(0, 3, 5),
                new Edge(1, 3, 15),
                new Edge(2, 3, 4),
                new Edge(4, 5, 2),
                new Edge(6, 7, 1),
                new Edge(8, 9, 3)
            };

            List<Edge> mst = KruskaMST(edges, size);

            Console.WriteLine("Minimum Spanning Tree Edges:");
            foreach (var edge in mst)
            {
                Console.WriteLine($"{edge.Source} - {edge.Destination} : {edge.Weight}");
            }

            Console.ReadLine(); // Keep console window open in Visual Studio
        }

        /// <summary>
        /// Represents an edge between two vertices with a certain weight.
        /// </summary>
        public class Edge
        {
            public int Source { get; set; }
            public int Destination { get; set; }
            public int Weight { get; set; }

            public Edge(int source, int destination, int weight)
            {
                Source = source;
                Destination = destination;
                Weight = weight;
            }
        }

        /// <summary>
        /// Finds the Minimum Spanning Tree (MST) using Kruskal's algorithm.
        /// </summary>
        /// <param name="edges">List of edges in the graph.</param>
        /// <param name="vertices">Number of vertices in the graph.</param>
        /// <returns>List of edges in the MST.</returns>
        public static List<Edge> KruskaMST(List<Edge> edges, int vertices)
        {
            edges.Sort((a, b) => a.Weight.CompareTo(b.Weight)); // Sort edges by weight

            DisjointSet disjointSet = new DisjointSet(vertices);
            List<Edge> result = new List<Edge>();

            foreach (var edge in edges)
            {
                if (!disjointSet.Connected(edge.Source, edge.Destination))
                {
                    result.Add(edge);
                    disjointSet.Union(edge.Source, edge.Destination);
                }

                // Stop early if MST is complete (V-1 edges)
                if (result.Count == vertices - 1)
                {
                    break;
                }
            }

            return result;
        }
    }
}