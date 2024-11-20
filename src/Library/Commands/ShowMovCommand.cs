using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

public class ShowMovCommand: ModuleBase<SocketCommandContext>
{
    [Command("showmov")]
    [Summary("Permite el ususario saber cuales movimientos tiene disponibles su pokemon actual")]

    public async Task ExecuteAsync()
    {
        string userName= CommandHelper.GetDisplayName(Context);
        if (Facade.Instance.IsBattleOngoing())
        {
            if (userName == Facade.Instance.JugadorA())
            {
                var result = Facade.Instance.ShowAvailableMoves();
                await ReplyAsync($"Movimientos disponibles de {Facade.Instance.ShowAtualPokemonA()}: {result}");
            }
            if (userName == Facade.Instance.JugadorD())
            {
                var result = Facade.Instance.ShowAvailableMoves();
                await ReplyAsync($"Movimientos disponibles de {Facade.Instance.ShowAtualPokemonD()}: {result}");
            }
            await ReplyAsync("No se ha encontrado al jugador.");
        }
        await ReplyAsync("La batalla ya ha finalizado.");
    }
    
}