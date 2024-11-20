using System.Text.Json;
using Microsoft.Extensions.Logging;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'showpokemons' del bot.
/// Este comando retorna una lista de Pokémon.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ShowPokemonsCommand : ModuleBase<SocketCommandContext>
{
    private readonly ILogger<ShowPokemonsCommand> logger;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ShowPokemonsCommand"/>.
    /// </summary>
    /// <param name="logger">El servicio de logging a utilizar.</param>
    public ShowPokemonsCommand(ILogger<ShowPokemonsCommand> logger)
    {
        this.logger = logger;
    }

    /// <summary>
    /// Implementa el comando 'showpokemons'. Este comando retorna
    /// la lista de Pokémon disponibles.
    /// </summary>
    [Command("showpokemons")]
    [Summary("Muestra la lista de Pokémon disponibles.")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        try
        {
            // Llama al método que devuelve la lista de Pokémon
            var result = Facade.Instance.ShowCatolog();

            if (string.IsNullOrEmpty(result))
            {
                await ReplyAsync("No hay Pokémon disponibles.");
            }
            else
            {
                // Responde con la lista de Pokémon
                await ReplyAsync($"Pokémon disponibles: {result}");
            }
        }
        catch (Exception exception)
        {
            logger.LogError("Error al mostrar los Pokémon: {Message}", exception.Message);
            await ReplyAsync("Ocurrió un error al intentar mostrar los Pokémon.");
        }
    }
}