using DefaultNamespace;

//Dormir:
//La clase Envenenar tiene una responsabilidad clara: gestionar el efecto de "envenenar" de un Pokémon, lo cual 
//está alineado con el SRP.
//OCP: La clase Envenenar puede extenderse con nuevos comportamientos derivados de Efecto sin necesidad de 
//modificar la clase base. 
//LSP: La clase Envenenar es una subclase de Efecto, y puede ser utilizada donde se espera un objeto Efecto.

namespace Library.Tipos;

public class Envenenar:Efecto
{
    /// <summary>  
    /// Inicializa una nueva instancia de la clase <see cref="Envenenar"/>.  
    /// </summary>  
    public Envenenar()
    {
        
    }

    /// <summary>  
    /// Aplica el efecto de envenenar al Pokémon.  
    /// Muestra un mensaje indicando que el Pokémon ha sido envenenado   
    /// y aplica daño al Pokémon correspondiente.  
    /// </summary>  
    /// <param name="pokemon">El Pokémon que va a recibir el efecto de envenenamiento.</param>  
    public override string HacerEfecto(Pokemon pokemon)
    {
        return $"{pokemon.GetName()} ha sido envenenado" + pokemon.RecibirDanioDeEfecto(5);
    }
}