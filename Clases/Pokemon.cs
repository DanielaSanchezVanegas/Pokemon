namespace PokemonAPI.Clases;

public class Pokemon : IPokemon
{
    private List<PokemonDTO> DB;

    public Pokemon(){
        this.DB = new List<PokemonDTO>();
    }

    public void Add(PokemonDTO pokemon)
    {
        this.DB.Add(pokemon);
    }

    public List<PokemonDTO> All()
    {
        return this.DB;
    }

    public void Delete(int id)
    {
        this.DB.RemoveAll(pokemon => pokemon.Id == id);
    }

    public void Update(int id, PokemonDTO pokemon)
    {
        PokemonDTO pokemonUpdate = this.DB.Single(pokemon => pokemon.Id == id);
        pokemonUpdate.Nombre = pokemon.Nombre;
        pokemonUpdate.Tipo = pokemon.Tipo;
        pokemonUpdate.Habilidades = pokemon.Habilidades;
        pokemonUpdate.Defensa = pokemon.Defensa;
    }
}