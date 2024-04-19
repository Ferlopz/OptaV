using Repository.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class FacturaService
    {
        FacturaRepository facturaRepository;

        public FacturaService(string connectionString)
        {
            facturaRepository = new FacturaRepository(connectionString);
        }

        public bool add(FacturaModel modelo)
        {
            if (validacionFactura(modelo) == 11)
                return facturaRepository.add(modelo);
            else
                return false;
        }

        public bool update(FacturaModel model1, int id_fac)
        {
            if (validacionFactura(model1) == 11)
                return facturaRepository.updateFactura(model1, id_fac);
            else
                return false;
        }

        public bool delete(string Nro_Factura)
        {
            return facturaRepository.remove(Nro_Factura);
        }

        public FacturaModel get(string Nro_Factura)
        {
            return facturaRepository.get(Nro_Factura);
        }

        public bool list()
        {
            return facturaRepository.listar();
        }

        public int validacionFactura(FacturaModel factura)
        {
            if (factura == null)
                return 1;
            else if (factura.Total == 0)
                return 2;
            else if (factura.Total_iva5 == 0)
                return 3;
            else if (factura.Total_iva10 == 0)
                return 4;
            else if (factura.Total_iva == 0)
                return 5;
            else if (factura.Nro_Factura.Length != 15)
                return 13;
            else if (EsNumerico(factura.Nro_Factura.Substring(0, 3)) == false)
                return 6;
            else if (CuartoCaracter(factura.Nro_Factura.Substring(3, 1)) == false)
                return 7;
            else if (EsNumerico(factura.Nro_Factura.Substring(4, 3)) == false)
                return 8;
            else if (CuartoCaracter(factura.Nro_Factura.Substring(7, 1)) == false)
                return 9;
            else if (EsNumerico(factura.Nro_Factura.Substring(8, 6)) == false)
                return 10;
            else if (factura.Total_letras.Length < 6)
                return 12;
            /*else if (cliente.Celular.Length > 10)
                return 6;
            else if (EsNumerico(cliente.Celular))
            {
                return 7;
            }
            else
            {
                return 8;
            }*/
            return 11;
        }

        private bool EsNumerico(string valor)
        {
            return Regex.IsMatch(valor, @"^\d+$");
        }

        private bool CuartoCaracter(string valor1)
        {
            if (valor1 == "-")
                return true;
            else
                return false;
        }

    }
}
