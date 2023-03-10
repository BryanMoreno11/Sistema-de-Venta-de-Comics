using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentadeComics
{
    public class EditorialCD
    {
        public static List<CP_ListarEditorialResult> ListarEditorial(string val)
        {
            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    return DB.CP_ListarEditorial(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar PA Editorial", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarEditorial(Entidades.Editorial oe)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_InsertarEditorial(oe.Nombre, oe.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Genero", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarEditorial(Entidades.Editorial oe)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {

                    DB.CP_ModificarEditorial(oe.Id, oe.Nombre, oe.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla Genero", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarEditorial(Entidades.Editorial oe)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_EliminarEditorial(oe.Id);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar un registro de la tabla Genero", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
