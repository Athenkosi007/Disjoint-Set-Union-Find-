using System;
using System.Collections.Generic;

class DisjointSet
{
    private Dictionary<int, int> parent = new Dictionary<int, int>();

    public void MakeSet(int x)
    {
        if (!parent.ContainsKey(x))
            parent[x] = x;
    }

    public int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]); // Path compression
        return parent[x];
    }

    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY)
            parent[rootY] = rootX;
    }

    public bool Connected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}

// Example usage
class Program
{
    static void Main()
    {
        var ds = new DisjointSet();

        for (int i = 1; i <= 5; i++)
            ds.MakeSet(i);

        ds.Union(1, 2);
        ds.Union(3, 4);

        Console.WriteLine(ds.Connected(1, 2)); // True
        Console.WriteLine(ds.Connected(2, 3)); // False

        ds.Union(2, 3);
        Console.WriteLine(ds.Connected(1, 4)); // True
    }
}
