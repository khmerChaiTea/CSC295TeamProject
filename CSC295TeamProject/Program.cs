namespace CSC295TeamProject
{
    class Program
    {
        static void Main()
        {
            // Example usage of DisjointSet

            int size = 10;  // Size of the DisjointSet

            // Create a new DisjointSet with size 10
            DisjointSet ds = new DisjointSet(size);

            // Perform some union operations
            ds.Union(0, 1);
            ds.Union(2, 3);
            ds.Union(4, 5);
            ds.Union(6, 7);
            ds.Union(0, 2);

            // Find operations
            Console.WriteLine("Find(1): " + ds.Find(1)); // Should print the root of set containing 1
            Console.WriteLine("Find(3): " + ds.Find(3)); // Should print the root of set containing 3
            Console.WriteLine("Find(5): " + ds.Find(5)); // Should print the root of set containing 5

            // Perform more union operations
            ds.Union(1, 3);
            ds.Union(4, 6);

            // Find operations after unions
            Console.WriteLine("Find(3): " + ds.Find(3)); // Should print the root of set containing 3
            Console.WriteLine("Find(5): " + ds.Find(5)); // Should print the root of set containing 5
            Console.WriteLine("Find(7): " + ds.Find(7)); // Should print the root of set containing 7

            // Note: You can add more test cases or operations as needed

            Console.ReadLine(); // Keep console window open in Visual Studio
        }
    }
}
