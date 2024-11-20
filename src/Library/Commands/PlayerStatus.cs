using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'showplayerstatus' del bot.
/// Permite al jugador obtener el estado actual de su equipo Pokémon.
/// </summary>
// ReSharper disable once UnusedType.Global
public class PlayerStatusCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'Playerstatus'.
    /// </summary>
    [Command("Playerstatus")]
    [Summary(
        """
        Muestra el estado actual del equipo Pokémon del jugador
        que envía el comando.
        """)]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        try
        {
            // Obtenemos el nombre del jugador desde el autor del mensaje
            string userName = CommandHelper.GetDisplayName(Context);;

            // Verificamos si el jugador está en la batalla y es su turno
            if (userName == Facade.Instance.JugadorA())
            {
                // Obtenemos el estado del equipo desde la fachada
                string status = Facade.Instance.ShowPlayerStatus();

                await ReplyAsync(status);
            }
            else
            {
                // El jugador no está en la batalla o no es su turno
                await ReplyAsync("No estás actualmente en una batalla o no es tu turno master");
            }
        }
        catch (Exception ex)
        {
            // Capturamos errores y notificamos al jugador
            await ReplyAsync($"Ocurrió un error: {ex.Message}");
        }
    }
}