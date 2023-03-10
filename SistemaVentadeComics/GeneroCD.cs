using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentadeComics
{
    public class GeneroCD
    {
        public static List<CP_ListarGeneroFiltroResult> ListarGeneroFiltro(string val)
        {
            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    return DB.CP_ListarGeneroFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar PA Genero", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarGenero(Entidades.Genero og)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_InsertarGenero(og.Nombre,og.Descripcion);
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

        public static void ModificarGenero(Entidades.Genero og)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {

                    DB.CP_ModificarGenero(og.Id, og.Nombre, og.Descripcion);
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

        public static void EliminarGenero(Entidades.Genero og)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_EliminarGenero(og.Id);
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
