using Library.Tipos;

namespace Ucu.Poo.Pokemon;
//Interfaz IMovimiento:
//Tiene alta cohesion, ya que se enfoca en un propósito específico: proporcionar la firma de los métodos necesarios para 
//acceder al nombre y tipo de un movimiento. Tambien cumple con SRP
//Polimorfismo: culquier clase que implemente IMovimiento puede ser tratada de la misma manera, utilizando los métodos 
//GetName() y GetTipo(). Esto facilita el polimorfismo en la lógica de combate de Pokémon, ya que se puede manejar una 
//colección de movimientos de diferentes tipos de manera uniforme.
//Cumple con OCP:  La interfaz está abierta para la extensión (se pueden agregar nuevas implementaciones de movimientos) 
//pero cerrada para la modificación (no se necesita modificar la interfaz para agregar nuevas clases de movimientos).
//Cumple con LSP: Las clases que implementan IMovimiento pueden ser sustituidas entre sí sin afectar al sistema, siempre 
//y cuando respeten el contrato de la interfaz, es decir, implementando los métodos GetName() y GetTipo() correctamente.


public interface IMovimiento
{ 
    /// <summary>
    /// Obtiene el nombre del movimiento.
    /// </summary>
    /// <returns>El nombre del movimiento.</returns>
    string GetName();
    
    /// <summary>
    /// Obtiene el tipo del movimiento.
    /// </summary>
    /// <returns>El tipo de movimiento como una instancia de <see cref="Tipo"/>.</returns>
    Tipo GetTipo();
    
}