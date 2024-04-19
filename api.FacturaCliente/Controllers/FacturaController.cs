using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Datos;
using Services.Logica;

namespace api.FacturaCliente.Controllers
{
    public class FacturaController : Controller
    {

        private FacturaService facturaService;
        private FacturaRepository facturaRepository;
        public FacturaController(IConfiguration configuracion)
        {
            facturaService = new FacturaService(configuracion.GetConnectionString("postgres"));
            facturaRepository = new FacturaRepository(configuracion.GetConnectionString("postgres"));
        }

        // GET: FacturaController
        [HttpPost("AddFactura")]
        public ActionResult Add(Repository.Datos.FacturaModel factura)
        {
            var validacion = facturaService.validacionFactura(factura);

            if (Mensaje(validacion) == "Ok")
            {
                facturaService.add(factura);
                return Ok(new { message = $"La factura Nroº {factura.Nro_Factura} fue insertado correctamente" });
            }
            else
            {
                return Ok(new { message = mensajeError });
            }
        }

        // GET: ClienteController/Edit/5
        [HttpPost("UpdateFactura")]
        public ActionResult Update(Repository.Datos.FacturaModel factura, int id_fac)
        {
            var validacion = facturaService.validacionFactura(factura);
            if (Mensaje(validacion) == "Ok")
            {
                facturaService.update(factura, id_fac);
                return Ok(new { message = $"La factura Nroº {factura.Nro_Factura} fue actualizado correctamente" });
            }
            else
            {
                return Ok(new { message = mensajeError });
            }
        }

        // GET: FacturaController/Delete/5
        [HttpDelete("DeleteFactura")]
        public ActionResult Delete(string Nro_Factura)
        {
            facturaService.delete(Nro_Factura);
            return Ok(new { message = $"La factura fue eliminada correctamente" });
        }

        [HttpGet]
        [Route("ConsultarFactura")]
        public ActionResult get(string Nro_Factura)
        {
            try
            {
                var factura = facturaService.get(Nro_Factura);
                if (factura != null)
                    return Ok(factura);
                else
                    return BadRequest("Fctura no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarFactura")]
        public ActionResult list()
        {
            try
            {
                var factura = facturaRepository.List();
                if (factura != null)
                    return Ok(factura);
                else
                    return BadRequest("No hay clientes registrados");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        string? mensajeError;

        private string Mensaje(int valor)
        {
            if (valor == 1)
            {
                mensajeError = "Complete los campos";
                return mensajeError;
            }
            else if (valor == 2)
            {
                mensajeError = "Ingrese el total";
                return mensajeError;
            }
            else if (valor == 3)
            {
                mensajeError = "Ingrese el total iva5";
                return mensajeError;
            }
            else if (valor == 4)
            {
                mensajeError = "Ingrese el total iva10";
                return mensajeError;
            }
            else if (valor == 5)
            {
                mensajeError = "Ingrese el total iva";
                return mensajeError;
            }
            else if (valor == 6 || valor == 8 || valor == 10)
            {
                mensajeError = "Los factura debe contener números";
                return mensajeError;
            }
            else if (valor == 7)
            {
                mensajeError = "Debe tener guión el Nroº de factura en la 4ta posición";
                return mensajeError;
            }
            else if (valor == 9)
            {
                mensajeError = "Debe tener guión el Nroº de factura en la 8va posición";
                return mensajeError;
            }
            else if (valor == 12)
            {
                mensajeError = "El total en letras debe contener al menos 6 caracteres";
                return mensajeError;
            }
            else if (valor == 13)
            {
                mensajeError = "El Nroº de factura debe contener 15 caracteres";
                return mensajeError;
            }
            mensajeError = "Ok";
            return mensajeError;
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
