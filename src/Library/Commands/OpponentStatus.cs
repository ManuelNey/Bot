using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'showopponentstatus' del bot.
/// Permite al jugador obtener el estado actual del equipo del oponente.
/// </summary>
// ReSharper disable once UnusedType.Global
public class OpponentStatusCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'opponentstatus'.
    /// </summary>
    [Command("OpponentStatus")]
    [Summary(
        """
        Muestra el estado actual del equipo Pokémon del oponente
        al jugador que envía el comando.
        """)]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        try
        {
            // Obtenemos el nombre del jugador desde el autor del mensaje
            string userName = CommandHelper.GetDisplayName(Context);

            // Verificamos si el jugador está en la batalla y es su turno
            if (userName == Facade.Instance.JugadorA())
            {
                // Obtenemos el estado del equipo del oponente desde la fachada
                string opponentStatus = Facade.Instance.ShowOpponentStatus();

                await ReplyAsync(opponentStatus);
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