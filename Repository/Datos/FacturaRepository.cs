using Dapper;
using Repository.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    public class FacturaRepository : IFactura
    {

        private IDbConnection conexionDB;
        public FacturaRepository(string _connectionString)
        {
            conexionDB = new DbConection(_connectionString).dbConnection();
        }

        public bool add(FacturaModel factura)
        {
            try
            {
                if (conexionDB.Execute("insert into factura (id_cliente, nro_factura, fecha_hora,total, total_iva5, total_iva10, total_iva, total_letras, sucursal) values (@id_cliente, @nro_factura, @fecha_hora, @total, @total_iva5, @total_iva10, @total_iva, @total_letras, @sucursal)", factura) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FacturaModel get(string Nro_Factura)
        {
            try
            {
                return conexionDB.Query<FacturaModel>("Select * from Factura where nro_factura = @nro_factura", new { Nro_Factura }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<FacturaModel> List()
        {
            try
            {
                return conexionDB.Query<FacturaModel>("Select * from Factura");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool listar()
        {
            try
            {
                if (conexionDB.Execute("Select * from Factura") > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updateFactura(FacturaModel factura, int id_fac)
        {
            try
            {
                if (conexionDB.Execute("Update Factura set id = @id, id_cliente = @id_cliente, sucursal = @sucursal, " +
                            "fecha_hora = @fecha_hora, total = @total, total_iva5 = @total_iva5, total_iva10 = @total_iva10, total_iva = @total_iva, total_letras= @total_letras " +
                            "where nro_factura = @nro_factura", factura) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(FacturaModel factura)
        {
            throw new NotImplementedException();
        }

        public bool remove(string Nro_Factura)
        {
            try
            {
                if (conexionDB.Execute("Delete from Factura where nro_factura = @nro_factura", new { Nro_Factura }) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
