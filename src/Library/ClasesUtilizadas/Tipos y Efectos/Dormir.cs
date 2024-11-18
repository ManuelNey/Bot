using DefaultNamespace;

namespace Library.Tipos;
//Dormir:
//La clase Dormir tiene una responsabilidad clara: gestionar el efecto de "dormir" de un Pokémon, lo cual 
//está alineado con el SRP.
//OCP: La clase Dormir puede extenderse con nuevos comportamientos derivados de Efecto sin necesidad de 
//modificar la clase base. 
//LSP: La clase Dormir es una subclase de Efecto, y puede ser utilizada donde se espera un objeto Efecto.


public class Dormir:Efecto
{
    private int turnos;
    private Random random = new Random();
    
    /// <summary>  
    /// Inicializa una nueva instancia de la clase <see cref="Dormir"/> y establece un número aleatorio  
    /// de turnos de sueño entre 1 y 4.  
    /// </summary>  
    public Dormir()
    {
        this.turnos = random.Next(1, 5);
    }
    
    /// <summary>  
    /// Aplica el efecto de dormir al Pokémon.  
    /// Si el número de turnos se ha reducido a 0, el Pokémon puede atacar de nuevo.  
    /// De lo contrario, se indica que el Pokémon está dormido y no puede atacar.  
    /// </summary>  
    /// <param name="pokemon">El Pokémon al que se le aplicará el efecto de dormir.</param>  
    public override string HacerEfecto(Pokemon pokemon)
    {
       
        if (this.turnos == 0)
        {
            pokemon.SetPuedeAtacar(true);
            pokemon.EliminarEfectoActual();
            return $"El pokemon {pokemon.GetName()} se la ha acabado el Efecto Dormir";
        }
        pokemon.SetPuedeAtacar(false);
        this.turnos -= 1;
        return $"{pokemon.GetName()} dormira durante {turnos} turnos";
    }
}