using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoCredito
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    var query = (from tipo in context.TipoCreditos
                                 select new
                                 {
                                     IdTipoCredito = tipo.IdTipoCredito,
                                     Nombre = tipo.Nombre
                                 }).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.TipoCredito tipoCredito = new ML.TipoCredito();
                            tipoCredito.IdTipoCredito = item.IdTipoCredito;
                            tipoCredito.Nombre = item.Nombre;

                            result.Objects.Add(tipoCredito);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los tipos de crédito.";
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
