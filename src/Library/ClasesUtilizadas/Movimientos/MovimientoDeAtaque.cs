using Library.Tipos;

namespace Ucu.Poo.Pokemon;

//Clase MovimientoDeAtaque:
//Cumple con el SRP porque tiene una sola tarea: representar un ataque en el juego. 
//Es un experto en su información, ya que maneja todo lo necesario para un movimiento 
//de ataque (como el nombre, el daño, el tipo y la precision). 
//Usa polimorfismo al implementar la interfaz IMovimientoAtaque, lo que le permite 
//ser utilizada de manera flexible en otras partes del código. 
//Además, sigue el LSP, ya que se puede usar en lugar de cualquier otra clase que 
//implemente la misma interfaz sin causar problemas.


public class MovimientoDeAtaque: IMovimientoAtaque
{
    private string Name { get; set; }
    private int Ataque { get; set; }
    private Tipo Tipo { get; set; }
    
    private int Precision { get; set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="MovimientoDeAtaque"/>.
    /// </summary>
    /// <param name="name">Nombre del movimiento de ataque.</param>
    /// <param name="ataque">Daño que causa el movimiento de ataque.</param>
    /// <param name="tipo">Tipo del movimiento de ataque.</param>
    /// <param name="precision">Precisión del movimiento de ataque.</param>
    public MovimientoDeAtaque(string name, int ataque, Tipo tipo, int precision)
    {
        this.Name = name;
        this.Ataque = ataque;
        this.Tipo = tipo;
        this.Precision = precision;
    }
    
    /// <summary>
    /// Obtiene el daño que causa el movimiento de ataque.
    /// </summary>
    /// <returns>El valor del daño.</returns>
    public int GetAtaque()
    {
        return Ataque;
    }

    /// <summary>
    /// Obtiene el nombre del movimiento de ataque.
    /// </summary>
    /// <returns>El nombre del movimiento.</returns>
    public string GetName()
    {
        return Name;
    }

    /// <summary>
    /// Obtiene el tipo del movimiento de ataque (e.g., Fuego, Agua, Planta, etc.).
    /// </summary>
    /// <returns>El tipo de movimiento de ataque.</returns>
    public Tipo GetTipo()
    {
        return Tipo;
    }

    /// <summary>
    /// Obtiene la precisión del movimiento de ataque, es decir, la probabilidad de acertar el ataque.
    /// </summary>
    /// <returns>La precisión del movimiento.</returns>
    public int GetPrecision()
    {
        return Precision;
    }
}