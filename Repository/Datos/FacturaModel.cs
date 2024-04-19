using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    public class FacturaModel
    {
        public int id_fac { get; set; }

        public int id_cliente { get; set; }

        public string? Nro_Factura { get; set; }

        public DateTime Fecha_Hora { get; set; }

        public double Total { get; set; }

        public double Total_iva5 { get; set; }

        public double Total_iva10 { get; set; }

        public double Total_iva { get; set; }

        public string? Total_letras { get; set; }

        public string? Sucursal { get; set; }
    }
}
