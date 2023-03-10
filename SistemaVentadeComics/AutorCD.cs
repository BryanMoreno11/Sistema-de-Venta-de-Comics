using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentadeComics
{
    public class AutorCD
    {
        public static List<CP_ListarAutorFiltroResult> ListarAutorFiltro(string val)
        {
            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    return DB.CP_ListarAutorFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar PA Autor", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarAutor(Entidades.Autor oa)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_InsertarAutor(oa.Nombre, oa.Apellido, oa.Descripcion, oa.Imagen);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Autor", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarAutor(Entidades.Autor oa)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {

                    DB.CP_ModificarAutor(oa.Id, oa.Nombre,oa.Apellido, oa.Descripcion, oa.Imagen);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla Autor", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarAutor(Entidades.Autor oa)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_EliminarAutor(oa.Id);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar un registro de la tabla Autor", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
