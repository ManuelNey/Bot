using DefaultNamespace;
using Library.Combate;
using Library.Tipos;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.Pokemon;

namespace AdapterNamespace;

public class AdapterTrainer: Trainer
{
    private readonly Jugador _jugador;
    
    public AdapterTrainer(string name) : base(name)
    {
        Jugador _jugador = new Jugador(name);
    }

    public bool GetpokemonEnTurnoAtaca()
    {
        return _jugador.GetPokemonEnTurnoAtaca();
    }

    public string HacerEfectoPokemonEnTurno(Pokemon pokemon)
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.HacerEfectoPokemon(pokemon);
    }

    public Efecto GetEfectoPokemonTurno()
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.GetEfecto();
    }

    public string PokemonAtacado(IMovimientoAtaque ataque)
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.RecibirAtaque(ataque);
    }

    public int GetCantpokemon()
    {
        List<Pokemon> listapokemones = _jugador.GetPokemons();
        return listapokemones.Count;
    }

    public bool PokemonEnTurnoAlive()
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.GetIsAlive();
    }

    public string GetName()
    {
        return _jugador.GetName();
    }

    public bool TeamIsalive()
    {
        return _jugador.TeamIsAlive();
    }

    public string AgregarAlEquipo(string name)
    {
        return _jugador.AgregarAlEquipo(name);
    }

    public void ActualizarEstadoEquipo()
    {
        _jugador.ActualizarEstadoEquipo();
    }

    public void CambiarPokemon(Pokemon pokemon)
    {
        _jugador.CambiarPokemon(pokemon);
    }

    public Pokemon GetPokemonEnTurno()
    {
        return _jugador.GetPokemonEnTurno();
    }

    public double HpPokemonEnTurno()
    {
        return _jugador.HpPokemonEnTurno();
    }

    public string MostarEstadoEquipo()
    {
        return _jugador.MostarEstadoEquipo();
    }

    public string UseItem(string item, Pokemon pokemon)
    {
        return _jugador.UsarItem(item, pokemon);
    }

    public string MostrarItems()
    {
        return _jugador.MostrarItems();
    }
}