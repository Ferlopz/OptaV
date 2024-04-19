using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    public class ClienteModel
    {
        public int id_cli { get; set; }

        public int id_banco { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Documento { get; set; }

        public string? Direccion { get; set; }

        public string? Mail { get; set; }

        public string? Celular { get; set; }

        public int Estado { get; set; }

    }
}
