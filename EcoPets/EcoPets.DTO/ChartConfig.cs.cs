using System.Collections.Generic;

namespace EcoPets.DTO
{
    public class ChartConfig
    {
        /// <summary>
        /// Identificador único del gráfico (debe coincidir con el ID del elemento canvas en el frontend).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Título que se mostrará en la tarjeta del gráfico.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Tipo de gráfico (e.g., "bar", "line", "pie").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Etiquetas para el eje X o para las categorías del gráfico.
        /// </summary>
        public List<string> Labels { get; set; }

        /// <summary>
        /// Datos numéricos correspondientes a las etiquetas.
        /// </summary>
        public List<int> Data { get; set; }

        /// <summary>
        /// Etiqueta descriptiva del conjunto de datos.
        /// </summary>
        public string Label { get; set; }
    }
}
