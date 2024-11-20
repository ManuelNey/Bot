using Microsoft.Extensions.Logging;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'addpokemon' del bot.
/// Este comando permite a los jugadores agregar un Pokémon a su equipo.
/// </summary>
// ReSharper disable once UnusedType.Global
public class UseMov : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'UseMov'. Este comando permite usar
    /// un movimiento con un número del 1 al 4.
    /// </summary>
    /// <param name="NumeroMov">El nombre del Pokémon a agregar.</param>
    [Command("usemov")]
    [Summary("Usa un movimiento del pokemon en turno")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder][Summary("Nombre del Pokémon")] int numero)
    {
        try
        {
            string nameplayer =  CommandHelper.GetDisplayName(Context);
            if (nameplayer == Facade.Instance.JugadorA())
            {
                string result = Facade.Instance.UsePokemonMove(numero);
                await ReplyAsync(result);
            }
            else
            {
                await ReplyAsync("No es tu turno capo, no te toca");
            }
        }
        catch (FormatException ex)
        {
            await ReplyAsync("El formato de la cadena no es válido.");
        }
    }
}