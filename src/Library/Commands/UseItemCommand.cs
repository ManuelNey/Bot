using System.Linq.Expressions;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

public class UseItemCommand: ModuleBase<SocketCommandContext>
{
    [Command("UseItem")]
    [Summary("Permite el ususario usar un item de su inventario")]

    public async Task ExecuteAsync([Remainder] [Summary("Nombre del Item")] string itemName,
        [Remainder] [Summary("Numero de pokemon")] int numpokemon)
    {
        string userName = CommandHelper.GetDisplayName(Context);
        ;
        string result = "";
        if (userName == Facade.Instance.JugadorA())
        {
            result += Facade.Instance.UseItem(itemName, numpokemon);
        }
        else if (userName == Facade.Instance.JugadorD())
        {
            result += Facade.Instance.UseItem(itemName, numpokemon);
        }
        else
        {
            result += "No es tu turno ni estás en la batalla, quedate quieto";
        }

        // Envía el resultado al usuario
        await ReplyAsync(result);
    }
}