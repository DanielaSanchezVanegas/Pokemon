using PokemonAPI.Clases;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<PokemonDTO> BD = new List<PokemonDTO>();
//Pokemon handler = new Pokemon();


//Crear un pokemon
app.MapPost("/api/v1/pokemon", (PokemonDTO pokemon)=>{
    BD.Add(pokemon);
    return Results.Ok(BD);
});

/*

*/

//Crear multiples pokemon
app.MapPost("/api/v1/pokemon/multiples", (PokemonDTO[] pokemons)=>{
    foreach (PokemonDTO pokemon in pokemons)
    {
        BD.Add(pokemon);
    }
    return Results.Ok(BD);
});


//Editar un pokemon
app.MapPut("/api/v1/pokemon/{id}", (int id, PokemonDTO pokemon)=>{
    PokemonDTO pokemonUpdate = BD.Single(pokemon=> pokemon.Id == id);
    pokemonUpdate.Nombre = pokemon.Nombre;
    pokemonUpdate.Tipo = pokemon.Tipo;
    pokemonUpdate.Habilidades = pokemon.Habilidades;
    pokemonUpdate.Defensa = pokemon.Defensa;
    return Results.Ok(BD);
});

//Eliminar un pokemon
app.MapDelete("/api/v1/pokemon/{id}", (int id)=>{
    return Results.Ok(BD.RemoveAll(pokemon => pokemon.Id == id ));
});

//Traer todos los pokemon
app.MapGet("/api/v1/pokemon", ()=>{
    return Results.Ok(BD);
});

//Traer un pokemon
app.MapGet("/api/v1/pokemon/{id}", (int id)=>{
    return Results.Ok(BD.Single(pokemon => pokemon.Id == id));
});

//Traer todos los pokemon de un tipo
app.MapGet("/api/v1/pokemon/tipo/{tipo}", (string tipo)=>{
    return Results.Ok(BD.Where(pokemon => pokemon.Tipo == tipo));
});


//Traer pokemon por el nombre
app.MapGet("/api/v1/pokemon/nombre/{nombre}", (string nombre)=>{
    return Results.Ok(BD.Where(pokemon => pokemon.Nombre == nombre));
});


//Traer todos los pokemon con mayor defensa 
app.MapGet("/api/v1/pokemon/defensa/{defensa}", (float defensa)=>{
    return Results.Ok(BD.Where(pokemon => pokemon.Defensa >= defensa));
});

//app.MapGet("/", () => "Hello World!");

app.Run();
