using Discord;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'initializebattle'. Este comando inicia
/// una batalla llamando al método InitializeBattle y devuelve su resultado.
/// </summary>
// ReSharper disable once UnusedType.Global
public class InitializeBattleCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'initializebattle'. Este comando llama al método
    /// InitializeBattle y responde con el resultado de la inicialización.
    /// </summary>
    [Command("StartBattle")]
    [Summary("Inicializa una batalla y devuelve el resultado.")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        // Llama al método InitializeBattle y obtiene el resultado
        string result = Facade.Instance.InitializeBattle();

        // Responde al usuario con el resultado
        await ReplyAsync(result);
    }
}