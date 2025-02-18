using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Solution
{
    public int solution(int[] A)
    {
        int N = A.Length;
        int target = 10;
        int totalBricks = A.Sum();

        // Check if it's possible to evenly distribute bricks
        if (totalBricks != N * target)
        {
            return -1;
        }

        int moves = 0;
        int balance = 0;

        // Iterate through the array to distribute the bricks
        for (int i = 0; i < N; i++)
        {
            balance += A[i] - target;
            moves += Math.Abs(balance);
        }

        return moves;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the file path containing the list of box values:");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: File not found.");
            return;
        }

        try
        {
            // Read the file, expecting one line with comma-separated numbers
            string[] lines = File.ReadAllLines(filePath);
            List<int[]> testCases = new List<int[]>();

            foreach (string line in lines)
            {
                int[] A = line.Split(',')
                              .Select(s => int.TryParse(s.Trim(), out int n) ? n : -1)
                              .Where(n => n >= 0) // Ensure valid numbers
                              .ToArray();

                if (A.Length > 0)
                    testCases.Add(A);
            }

            Solution sol = new Solution();
            Console.WriteLine("\nResults:");
            foreach (var test in testCases)
            {
                Console.WriteLine($"Test Case: [{string.Join(", ", test)}] -> Result: {sol.solution(test)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}
