using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kardex_Productos
{
    class Productos
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string FechaVencimiento { get; set; }
        public int Cantidad { get; set; }
        public string TipoDeCantidad { get; set; }
        public string FechaSalida { get; set; }
        public string Trabajador { get; set; }
    }
}
