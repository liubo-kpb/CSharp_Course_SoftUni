using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.PokemonDontGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;
            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removedElementValue = 0;
                int copiedElementValue = 0;
                bool indexWasChanged = false;
                if (index < 0)
                {
                    index = 0;
                    copiedElementValue = pokemons[pokemons.Count - 1];
                    indexWasChanged = true;
                }
                else if (index >= pokemons.Count)
                {
                    index = pokemons.Count - 1;
                    copiedElementValue = pokemons[0];
                    indexWasChanged = true;
                }

                removedElementValue = pokemons[index];
                sum += removedElementValue;
                pokemons[index] = copiedElementValue;
                if (!indexWasChanged)
                {
                    pokemons.RemoveAt(index);
                }
                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= removedElementValue)
                    {
                        pokemons[i] += removedElementValue;
                    }
                    else
                    {
                        pokemons[i] -= removedElementValue;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
