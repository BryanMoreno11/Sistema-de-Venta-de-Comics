using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace SistemaVentadeComics
{
    public class SerieCD
    {
        public static List<CP_ListarSerieFiltroResult> ListarSerieFiltro(string val)
        {
            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    return DB.CP_ListarSerieFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar PA actor", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarSerie(Entidades.Serie os)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_InsertarSerie(os.Nombre,os.Descripcion,os.Imagen);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Serie", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarSerie(Entidades.Serie os)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    
                    DB.CP_ModificarSerie(os.Id, os.Nombre, os.Descripcion, os.Imagen);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla Serie", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarSerie(Entidades.Serie os)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_EliminarSerie(os.Id);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar un registro de la tabla Serie", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
