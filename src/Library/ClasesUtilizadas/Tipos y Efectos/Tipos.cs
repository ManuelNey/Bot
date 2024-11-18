using System.Collections.Generic;

namespace Library.Tipos
{
    //Tipo:
//tiene una única responsabilidad, que es gestionar las efectividades entre tipos, por lo que cumple bien con el 
//principio de responsabilidad única.
//OCP: La clase está abierta a modificaciones, lo que es beneficioso si necesitas agregar nuevos tipos o efectos. 
//La capacidad de modificar las efectividades es flexible, pero puede llegar a necesitar ajustes si se expanden 
//las funcionalidades del sistema.
//LSP: Aunque la clase Tipo no tiene clases derivadas en tu diseño actual, si se decide extenderla en el futuro,
//por ejemplo, para tipos especiales o subtipos, los principios de la lógica de efectividad seguiran siendo consistentes.

    public class Tipo
    {
        private string name;
        
        private Dictionary<Tipo, double> efectividades = new Dictionary<Tipo, double>();
        
        /// <summary>  
        /// Inicializa una nueva instancia de la clase <see cref="Tipo"/> con un nombre específico.  
        /// </summary>  
        /// <param name="name">El nombre del tipo.</param>  
        public Tipo(string name)
        {
            this.name = name;
        }

        /// <summary>  
        /// Agrega o actualiza la efectividad de este tipo respecto a otro tipo.  
        /// </summary>  
        /// <param name="tipo">El tipo al que se le está definiendo la efectividad.</param>  
        /// <param name="efectividad">El valor de efectividad entre este tipo y el tipo especificado.</param>  
        public void CrearEfectividad(Tipo tipo, double efectividad)
        {
            if (!efectividades.ContainsKey(tipo))
            {
                efectividades.Add(tipo, efectividad);
            }
            else
            {
                efectividades[tipo] = efectividad;  // Actualiza si ya existe
            }
        }

        /// <summary>  
        /// Devuelve la efectividad de este tipo contra otro tipo.  
        /// Si la efectividad no está definida, se considera como neutro (1.0).  
        /// </summary>  
        /// <param name="tipo">El tipo al que se le quiere conocer la efectividad.</param>  
        /// <returns>El valor de efectividad de este tipo contra el tipo especificado.</returns>  
        public double DarEfectividad(Tipo tipo)
        {
            if (efectividades.ContainsKey(tipo))
            {
                return efectividades[tipo];
            }
            return 1.0;  // Si no está definido, lo consideramos como neutro
        }
    }
}