using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    public interface IFactura
    {
        bool add(FacturaModel factura);

        bool remove(string Nro_Factura);

        bool update(FacturaModel factura);

        FacturaModel get(string Nro_Factura);

        IEnumerable<FacturaModel> List();
    }
}
