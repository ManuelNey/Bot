using Microsoft.Extensions.Logging;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'addpokemon' del bot.
/// Este comando permite a los jugadores agregar un Pokémon a su equipo.
/// </summary>
// ReSharper disable once UnusedType.Global
public class AddPokemonCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'addpokemon'. Este comando permite agregar
    /// un Pokémon al equipo del usuario que ejecuta el comando.
    /// </summary>
    /// <param name="pokemonName">El nombre del Pokémon a agregar.</param>
    [Command("addpokemon")]
    [Summary("Agrega un Pokémon al equipo del usuario.")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder][Summary("Nombre del Pokémon")] string pokemonName)
    {
        if (string.IsNullOrWhiteSpace(pokemonName))
        {
            await ReplyAsync("Use: !addpokemon <nombrepokemon>");
            return;
        }

        string userName = CommandHelper.GetDisplayName(Context);
        string result = "";
        if (userName == Facade.Instance.JugadorA())
        {
            result += Facade.Instance.AddPokemosA(pokemonName);
        }
        else if (userName == Facade.Instance.JugadorD())
        { 
            result += Facade.Instance.AddPokemosD(pokemonName);
        }
        else
        {
            result += "No es tu turno ni estás en la batalla, quedate quieto";
        }
        // Envía el resultado al usuario
        await ReplyAsync(result);
    }
}