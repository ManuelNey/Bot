namespace Ucu.Poo.Pokemon
{
    //IMovimientoDefensa:
//Define las propiedades relacionadas con movimientos de defensa, lo que mantiene la cohesión de la interfaz.
//LSP: Puede ser sustituida por cualquier subclase que implemente esta interfaz. Tambien cumple con polimorfismo.
//Cumple con ISP: Debido a que esta separada de IMovimimentoAtaque e IMovimientoEspecial, cada una tiene sus metodos 
//correspondientes para cada tipo de movimiento, evitando que alguna tenga metodos irrelevantes.


    public interface IMovimientoDefensa : IMovimiento
    {
        /// <summary>
        /// Obtiene el valor de la defensa del movimiento.
        /// </summary>
        /// <returns>El valor de defensa del movimiento.</returns>
        int GetDefensa();
    }
}