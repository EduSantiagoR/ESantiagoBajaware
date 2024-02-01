using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Credito
    {
        public static ML.Result GetByCodCliente(int codCliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    var query = (from credito in context.Creditos
                                 join tipo in context.TipoCreditos on credito.IdTipoCredito equals tipo.IdTipoCredito
                                 where credito.CodCliente == codCliente
                                 select new
                                 {
                                     CodCredito = credito.CodCredito,
                                     Activo = credito.Activo,
                                     Monto = credito.Monto,
                                     FechaInicio = credito.FechaInicio,
                                     FechaVencimiento = credito.FechaVencimiento,
                                     IdTipoCredito = tipo.IdTipoCredito,
                                     NombreTipo = tipo.Nombre
                                 }).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Credito credito = new ML.Credito();
                            credito.CodCredito = item.CodCredito;
                            credito.Activo = item.Activo;
                            credito.Monto = item.Monto;
                            credito.FechaInicio = item.FechaInicio;
                            credito.FechaVencimiento = item.FechaVencimiento;
                            credito.TipoCredito = new ML.TipoCredito();
                            credito.TipoCredito.IdTipoCredito = item.IdTipoCredito;
                            credito.TipoCredito.Nombre = item.NombreTipo;

                            result.Objects.Add(credito);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los creditos.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(int codCredito)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    var credito = (from credit in context.Creditos where credit.CodCredito == codCredito select credit).First();
                    context.Creditos.Remove(credito);
                    int rowsAffected = context.SaveChanges();
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al eliminar el crédito.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"CreditoAdd {cliente.CodCliente}, {cliente.Credito.TipoCredito.IdTipoCredito}, {cliente.Credito.Activo}, {cliente.Credito.Monto}, '{cliente.Credito.FechaVencimiento.ToShortDateString()}'");
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al registrar el credito.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
