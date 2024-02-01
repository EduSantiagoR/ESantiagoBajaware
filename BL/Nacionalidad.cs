namespace BL
{
    public class Nacionalidad
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoBajawareContext context = new DL.EsantiagoBajawareContext())
                {
                    var query = (from nacionalidad in context.Nacionalidads
                                 select new
                                 {
                                     IdNacionalidad = nacionalidad.IdNacionalidad,
                                     Nombre = nacionalidad.Nombre
                                 }).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Nacionalidad nacionalidad = new ML.Nacionalidad();
                            nacionalidad.IdNacionalidad = item.IdNacionalidad;
                            nacionalidad.Nombre = item.Nombre;
                            
                            result.Objects.Add(nacionalidad);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar las nacionalidades.";
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
