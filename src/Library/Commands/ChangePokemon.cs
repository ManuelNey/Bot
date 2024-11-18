using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'battle' del bot. Este comando une al
/// jugador que envía el mensaje con el oponente que se recibe como parámetro,
/// si lo hubiera, en una batalla; si no se recibe un oponente, lo une con
/// cualquiera que esté esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ChangeCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'battle'. Este comando une al jugador que envía el
    /// mensaje a la lista de jugadores esperando para jugar.
    /// </summary>
    [Command("change")]
    [Summary(
        """
        Une al jugador que envía el mensaje con el oponente que se recibe
        como parámetro, si lo hubiera, en una batalla; si no se recibe un
        oponente, lo une con cualquiera que esté esperando para jugar.
        """)]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync(
        [Summary("Índice del Pokémon a cambiar (0 basado)")] 
        int? pokemonIndex = null)
    {
        try
        {
            // Validamos que se haya proporcionado un índice
            if (pokemonIndex == null)
            {
                await ReplyAsync("Debes especificar el índice del Pokémon que deseas usar. Ejemplo: `!changepokemon 0`.");
                return;
            }
            

            // Llamamos a la fachada para cambiar de Pokémon
            string result = Facade.Instance.ChangePokemon(pokemonIndex.Value);

            // Notificamos al jugador sobre el resultado
            await Context.Message.Author.SendMessageAsync(result);
            await ReplyAsync(result);
        }
        catch (Exception ex)
        {
            // Capturamos errores, como índices fuera de rango o jugador inexistente
            await ReplyAsync($"Ocurrió un error: {ex.Message}");
        }
    }
}