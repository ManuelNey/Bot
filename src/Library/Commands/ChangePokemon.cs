using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'changepokemon' del bot.
/// Permite al jugador cambiar el Pokémon en combate si es su turno
/// y está en una batalla.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ChangePokemonCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'changepokemon'.
    /// </summary>
    [Command("changepokemon")]
    [Summary(
        """
        Cambia el Pokémon activo del jugador que envía el mensaje.
        Proporciona el índice del Pokémon en el equipo como parámetro.
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
                await ReplyAsync("Debes especificar el índice del Pokémon que deseas usar. Ejemplo: `!changepokemon 1`.");
                return;
            }

            // Obtenemos el nombre del jugador desde el autor del mensaje
            string userName = CommandHelper.GetDisplayName(Context);;

            // Verificamos si el jugador está en la batalla y es su turno
            if (userName == Facade.Instance.JugadorA())
            {
                // Llamamos a la fachada para cambiar de Pokémon
                string result = Facade.Instance.ChangePokemon(pokemonIndex.Value);

                // Notificamos al jugador sobre el resultado
                await ReplyAsync(result);
            }
            else
            {
                // El jugador no está en la batalla o no es su turno
                await ReplyAsync("No estas en la batalla o no es tu turno master.");
            }
        }
        catch (Exception ex)
        {
            // Capturamos errores, como índices fuera de rango o jugador inexistente
            await ReplyAsync($"Ocurrió un error: {ex.Message}");
        }
    }
}
