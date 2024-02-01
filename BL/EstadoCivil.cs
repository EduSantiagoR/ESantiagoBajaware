using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstadoCivil
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    var query = (from estadoCivil in context.EstadoCivils
                                 select new
                                 {
                                     IdEstadoCivil = estadoCivil.IdEstadoCivil,
                                     Nombre = estadoCivil.Nombre
                                 }).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.EstadoCivil estadoCivil = new ML.EstadoCivil();
                            estadoCivil.IdEstadoCivil = item.IdEstadoCivil;
                            estadoCivil.Nombre = item.Nombre;

                            result.Objects.Add(estadoCivil);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los estados civiles.";
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
    }
}
