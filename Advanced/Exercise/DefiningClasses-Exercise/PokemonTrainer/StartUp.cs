using PokemonTrainer;

Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
string input = string.Empty;
while ((input = Console.ReadLine()) != "Tournament")
{
    string[] details = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string trainerName = details[0];
    string pokemonName = details[1];
    string pokemonElement = details[2];
    int pokemonHealth = int.Parse(details[3]);
    Trainer trainer = new Trainer(trainerName);
    if (!trainers.ContainsKey(trainerName))
    {
        trainers.Add(trainerName, trainer);
    }
    trainers[trainerName].CatchPokemon(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
}

while ((input = Console.ReadLine()) != "End")
{
    foreach (var trainer in trainers)
    {
        if (trainer.Value.Pokemons.Any(p => p.Element == input))
        {
            trainer.Value.Badges++;
        }
        else
        {
            trainer.Value.Pokemons.Select(p => p.Health -= 10);
            if (trainer.Value.Pokemons.Any(p => p.Health <= 0))
            {
                trainer.Value.PokemonDies(trainer.Value.Pokemons.Where(p => p.Health <= 0).ToList());
            }
        }
    }
}

foreach (var trainer in trainers.OrderByDescending(t => t.Value.Badges))
{
    Console.WriteLine(trainer.Value.ToString());
}