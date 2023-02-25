namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] universe = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sets = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[sets][];
            for (int i = 0; i < sets; i++)
            {
                jaggedArray[i] = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            List<int[]> selectedSets = ChooseSets(jaggedArray.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.Write("{ ");
                Console.Write(string.Join(", ", set));
                Console.WriteLine(" }");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>();
            
            while(universe.Count > 0)
            {
                int[] longestSet = sets.OrderByDescending(s => s.Count(x => universe.Contains(x))).FirstOrDefault();
                selectedSets.Add(longestSet);
                sets.Remove(longestSet);
                for (int i = 0; i < longestSet.Length; i++)
                {
                    universe.Remove(longestSet[i]);
                }
            }

            return selectedSets;
        }
    }
}
