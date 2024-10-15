using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.DTOs.Metrics
{
    public class MetricSummaryDto
    {
        public string MethodHttp { get; set; } // Metodo Http Ejecutado

        public DateTime Date  { get; set; } //Fecha Metrica

        public int ConsumptionQuantity { get; set; } //Tiempo de Consumo

        public string Endpoint { get; set; }

        public double AverageResponseTime { get; set; } // Tiempo promedio respuestas

        public long ResponseTimeMin { get; set; } //Tiempo Respueta Minima

        public long ResponseTimeMax { get; set;} //Tiempo Respuesta Maxima

        public double TPM { get; set; } //Transacciones Por Minuto

        public string Result { get; set; } //Resultado o Respuesta "OK" o "ERROR"



    }
}
