using Repository.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class ClienteService
    {
        ClienteRepository clienteRepository;

        public ClienteService(string connectionString)
        {
            clienteRepository = new ClienteRepository(connectionString);
        }

        public bool add(ClienteModel modelo)
        {
            if (validacionCliente(modelo) == 7)
                return clienteRepository.add(modelo);
            else
                return false;
        }

        public bool update(ClienteModel model1, int id_cli)
        {
            if (validacionCliente(model1) == 7)
                return clienteRepository.updateCliente(model1, id_cli);
            else
                return false;
        }

        public bool delete(string Documento)
        {
            return clienteRepository.remove(Documento);
        }

        public bool list()
        {
            return clienteRepository.listar();
        }

        public ClienteModel get(string documento)
        {
            return clienteRepository.get(documento);
        }

        public int validacionCliente(ClienteModel cliente)
        {
            if (cliente == null)
                return 1;
            else if (string.IsNullOrEmpty(cliente.Nombre))
                return 2;
            else if (string.IsNullOrEmpty(cliente.Apellido))
                return 3;
            else if (string.IsNullOrEmpty(cliente.Documento))
                return 4;
            else if (cliente.Nombre.Length < 3)
                return 5;
            else if (cliente.Celular.Length > 10)
                return 6;
            else if (EsNumerico(cliente.Celular))
            {
                return 7;
            }
            else
            {
                return 8;
            }
            //return true;
        }

        private bool EsNumerico(string valor)
        {
            return Regex.IsMatch(valor, @"^\d+$");
        }

    }
}
