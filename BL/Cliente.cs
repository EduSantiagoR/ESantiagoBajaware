using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cliente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    var query = (from cliente in context.Clientes
                                 join estCivil in context.EstadoCivils on cliente.IdEstadoCivil equals estCivil.IdEstadoCivil
                                 join nacion in context.Nacionalidads on cliente.IdNacionalidad equals nacion.IdNacionalidad
                                 select new
                                 {
                                     CodCliente = cliente.CodCliente,
                                     Nombre = cliente.Nombre,
                                     ApellidoPaterno = cliente.ApellidoPaterno,
                                     ApellidoMaterno = cliente.ApellidoMaterno,
                                     FechaNacimiento = cliente.FechaNacimiento,
                                     IdEstadoCivil = estCivil.IdEstadoCivil,
                                     NombreEstadoCivil = estCivil.Nombre,
                                     IdNacionalidad = nacion.IdNacionalidad,
                                     NombreNacionalidad = nacion.Nombre
                                 }).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Cliente cliente = new ML.Cliente();
                            cliente.CodCliente = item.CodCliente;
                            cliente.Nombre = item.Nombre;
                            cliente.ApellidoPaterno= item.ApellidoPaterno;
                            cliente.ApellidoMaterno= item.ApellidoMaterno;
                            cliente.FechaNacimiento = item.FechaNacimiento.Value;
                            cliente.EstadoCivil.IdEstadoCivil = item.IdEstadoCivil;
                            cliente.EstadoCivil.Nombre = item.NombreEstadoCivil;
                            cliente.Nacionalidad.IdNacionalidad = item.IdNacionalidad;
                            cliente.Nacionalidad.Nombre = item.NombreNacionalidad;

                            result.Objects.Add(cliente);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al consultar los clientes.";
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
        public static ML.Result GetById(int codCliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    var clienteConsultado = (from cliente in context.Clientes
                                 join estCivil in context.EstadoCivils on cliente.IdEstadoCivil equals estCivil.IdEstadoCivil
                                 join nacion in context.Nacionalidads on cliente.IdNacionalidad equals nacion.IdNacionalidad
                                 where cliente.CodCliente == codCliente
                                 select new
                                 {
                                     CodCliente = cliente.CodCliente,
                                     Nombre = cliente.Nombre,
                                     ApellidoPaterno = cliente.ApellidoPaterno,
                                     ApellidoMaterno = cliente.ApellidoMaterno,
                                     FechaNacimiento = cliente.FechaNacimiento,
                                     IdEstadoCivil = estCivil.IdEstadoCivil,
                                     NombreEstadoCivil = estCivil.Nombre,
                                     IdNacionalidad = nacion.IdNacionalidad,
                                     NombreNacionalidad = nacion.Nombre
                                 }).AsEnumerable().FirstOrDefault();
                    if(clienteConsultado != null)
                    {
                        ML.Cliente cliente = new ML.Cliente();
                        cliente.CodCliente = clienteConsultado.CodCliente;
                        cliente.Nombre = clienteConsultado.Nombre;
                        cliente.ApellidoPaterno = clienteConsultado.ApellidoPaterno;
                        cliente.ApellidoMaterno = clienteConsultado.ApellidoMaterno;
                        cliente.FechaNacimiento = clienteConsultado.FechaNacimiento.Value;
                        cliente.EstadoCivil.IdEstadoCivil = clienteConsultado.IdEstadoCivil;
                        cliente.EstadoCivil.Nombre = clienteConsultado.NombreEstadoCivil;
                        cliente.Nacionalidad.IdNacionalidad = clienteConsultado.IdNacionalidad;
                        cliente.Nacionalidad.Nombre = clienteConsultado.NombreNacionalidad;

                        result.Object = cliente;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al consultar el cliente.";
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
        public static ML.Result Delete(int codCliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    var query = (from cliente in context.Clientes where cliente.CodCliente == codCliente select cliente).First();
                    context.Clientes.Remove(query);
                    int rowsAffected = context.SaveChanges();
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al eliminar el cliente.";
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

        public static ML.Result Add(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    DL.Cliente nuevoCliente = new DL.Cliente();
                    nuevoCliente.Nombre = cliente.Nombre;
                    nuevoCliente.ApellidoPaterno = cliente.ApellidoPaterno;
                    nuevoCliente.ApellidoMaterno = cliente.ApellidoMaterno;
                    nuevoCliente.FechaNacimiento = cliente.FechaNacimiento;
                    nuevoCliente.IdEstadoCivil = cliente.EstadoCivil.IdEstadoCivil;
                    nuevoCliente.IdNacionalidad = cliente.Nacionalidad.IdNacionalidad;

                    context.Clientes.Add(nuevoCliente);
                    int rowsAffected = context.SaveChanges();
                    if(rowsAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al agregar el cliente.";
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
        public static ML.Result Update(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    var query = (from c in context.Clientes where c.CodCliente == cliente.CodCliente select c).ToList().SingleOrDefault();
                    if(query != null)
                    {
                        query.Nombre = cliente.Nombre;
                        query.ApellidoPaterno = cliente.ApellidoPaterno;
                        query.ApellidoMaterno = cliente.ApellidoMaterno;
                        query.FechaNacimiento = cliente.FechaNacimiento;
                        query.IdEstadoCivil = cliente.EstadoCivil.IdEstadoCivil;
                        query.IdNacionalidad = cliente.Nacionalidad.IdNacionalidad;

                        int rowsAffected = context.SaveChanges();
                        if(rowsAffected > 0 )
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Message = "Error al actualizar al cliente.";
                        }
                    }
                    else
                    {
                        result.Message = "Error al recuperar información del cliente en actualizar.";
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
