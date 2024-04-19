using Dapper;
using Microsoft.VisualBasic;
using Repository.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    public class ClienteRepository : ICliente
    {
        private IDbConnection conexionDB;
        public ClienteRepository(string _connectionString)
        {
            conexionDB = new DbConection(_connectionString).dbConnection();
        }

        public bool add(ClienteModel cliente)
        {
            try
            {
                if(conexionDB.Execute("insert into cliente (id_banco, nombre, apellido,documento, direccion, mail, celular, estado) values (@id_banco, @nombre, @apellido, @documento, @direccion, @mail, @celular, @estado)", cliente) > 0)
                     return true;
                else
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel get(string documento)
        {
            try
            {
                return conexionDB.Query<ClienteModel>("Select * from Cliente where documento = @documento", new { documento }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ClienteModel> List()
        {
            try
            {
            return conexionDB.Query<ClienteModel>("Select * from Cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool remove(ClienteModel cliente)
        {
            throw new NotImplementedException();
        }

        public bool update(ClienteModel cliente)
        {
            return false;
        }

        public bool updateCliente(ClienteModel cliente, int id_cli)
        {
            try
            {
                if (conexionDB.Execute("Update Cliente set id = @id, id_banco = @id_banco, nombre = @nombre, " +
                    "apellido = @apellido, direccion = @direccion, mail = @mail, celular = @celular, estado = @estado " +
                    "where documento = @documento" , cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(ClienteModel cliente, int id_cli)
        {
            return false;
        }

        public bool remove(string Documento)
        {
            try
            {
                if (conexionDB.Execute("Delete from Cliente where documento = @documento", new { Documento }) > 0)
                    return true;
                else
                    return false;
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
                if (conexionDB.Execute("SELECT * FROM public.\"Cliente\"") > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ClienteModel ICliente.get(string documento)
        {
            throw new NotImplementedException();
        }
    }

}
