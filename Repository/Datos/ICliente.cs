using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    internal interface ICliente
    {
        bool add(ClienteModel cliente);

        bool remove(string Documento);

        bool update(ClienteModel cliente);

        ClienteModel get(string documento);

        IEnumerable<ClienteModel> List();

    }
}
