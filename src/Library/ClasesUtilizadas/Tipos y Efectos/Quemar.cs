using System.Net.Mime;
using DefaultNamespace;

namespace Library.Tipos;

//Quemar:
//SRP: La clase tiene una sola responsabilidad, que es aplicar el efecto de quemado a un Pokémon. 
//OCP: La clase Quemar es fácil de extender en caso de que se desee añadir nuevas lógicas de efectos, como 
//diferentes probabilidades de quemar, sin modificar el código actual. 
//LSP:  La clase Quemar hereda de Efecto y se puede usar en cualquier lugar donde se espere un objeto Efecto


public class Quemar:Efecto
{
    // <summary>  
    /// Inicializa una nueva instancia de la clase <see cref="Quemar"/>.  
    /// </summary>  
    public Quemar()
    {
        
    }

    /// <summary>  
    /// Aplica el efecto de quemar al Pokémon.  
    /// Muestra un mensaje indicando que el Pokémon ha sido quemado   
    /// y aplica daño al Pokémon correspondiente.  
    /// </summary>  
    /// <param name="pokemon">El Pokémon al que se le aplicará el efecto de quemadura.</param>  
    public override string HacerEfecto(Pokemon pokemon)
    {
        string texto = pokemon.RecibirDanioDeEfecto(10);
        texto += $"\n{pokemon.GetName()}, ha sido Quemado";
        return texto;
    }
}