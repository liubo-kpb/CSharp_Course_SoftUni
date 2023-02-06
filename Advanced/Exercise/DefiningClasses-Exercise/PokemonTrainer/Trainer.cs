namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void CatchPokemon(Pokemon pokemon) => Pokemons.Add(pokemon);
        public void PokemonDies(List<Pokemon> pokemons)
        {
            while(pokemons.Count > 0)
            {
                Pokemons.Remove(pokemons[0]);
                pokemons.RemoveAt(0);
            }
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
