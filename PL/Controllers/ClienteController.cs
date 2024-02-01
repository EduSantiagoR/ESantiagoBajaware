using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Result result = BL.Cliente.GetAll();
            ML.Cliente cliente = new ML.Cliente() { Clientes = result.Objects };
            return View(cliente);
        }
        public IActionResult Form(int? codCliente)
        {
            ML.Result resultEstadoCivil = BL.EstadoCivil.GetAll();
            ML.Result resultNacionalidad = BL.Nacionalidad.GetAll();
            ML.Cliente cliente = new ML.Cliente();
            if (codCliente != null)
            {
                ML.Result result = BL.Cliente.GetById(codCliente.Value);
                cliente = (ML.Cliente)result.Object;
            }
            cliente.EstadoCivil.Estados = resultEstadoCivil.Objects;
            cliente.Nacionalidad.Nacionalidades = resultNacionalidad.Objects;
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Form(ML.Cliente cliente)
        {
            if(cliente.CodCliente == 0)
            {
                ML.Result result = BL.Cliente.Add(cliente);
                ViewBag.Mensaje = result.Correct ? "Cliente agregado correctamente." : "Error al registrar el cliente.";
            }
            else
            {
                ML.Result result = BL.Cliente.Update(cliente);
                ViewBag.Mensaje = result.Correct ? "Cliente actualizado correctamente." : "Error al actualizar el cliente.";
            }
            return PartialView("Modal");
        }
        public IActionResult Delete(int codCliente)
        {
            ML.Result result = BL.Cliente.Delete(codCliente);
            ViewBag.Mensaje = result.Correct ? "Cliente eliminado correctamente." : "Error al eliminar el cliente.";
            return PartialView("Modal");
        }
    }
}
