using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class CreditoController : Controller
    {
        public IActionResult GetByCodCliente(int codCliente)
        {
            ML.Result resultCreditos = BL.Credito.GetByCodCliente(codCliente);
            ML.Result resultCliente = BL.Cliente.GetById(codCliente);
            ML.Cliente cliente = new ML.Cliente();
            cliente = (ML.Cliente)resultCliente.Object;
            cliente.Credito.Creditos = resultCreditos.Objects;
            return View(cliente);
        }
        public IActionResult Form(int codCliente)
        {
            ML.Cliente cliente = new ML.Cliente();
            cliente.CodCliente = codCliente;

            ML.Result resultTipos = BL.TipoCredito.GetAll();
            cliente.Credito.TipoCredito = new ML.TipoCredito();
            cliente.Credito.TipoCredito.Tipos = resultTipos.Objects;

            return View(cliente);
        }
        [HttpPost]
        public IActionResult Form(ML.Cliente cliente)
        {
            ML.Result result = BL.Credito.Add(cliente);
            ViewBag.Mensaje = result.Correct ? "Crédito registrado correctamente." : "Error al registrar el crédito.";
            ViewBag.CodCliente = cliente.CodCliente;
            return PartialView("Modal");
        }
        public IActionResult Delete(int codCliente, int codCredito)
        {
            ML.Result result = BL.Credito.Delete(codCredito);
            ViewBag.CodCliente = codCliente;
            ViewBag.Mensaje = result.Correct ? "Crédito eliminado correctamente." : "Error al eliminar el crédito.";
            return PartialView("Modal");
        }
    }
}
