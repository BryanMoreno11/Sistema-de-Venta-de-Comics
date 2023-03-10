using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentadeComics
{
    public class ComicCD
    {
        public static List<CP_ListarVistaComicResult> ListarVistaComicFiltro(string val)
        {
            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    return DB.CP_ListarVistaComic(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar PA comic", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<CP_ListarComicFiltroResult> ListarComicFiltro(string val)
        {
            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    return DB.CP_ListarComicFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar PA comic", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarComic(Entidades.Comic oc)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_InsertarComic(oc.Nombre,oc.Id_serie,oc.Id_genero,oc.Id_autor,oc.Id_editorial,oc.Descripcion, oc.Precio, oc.Stock,oc.Imagen);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Comic", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarComic(Entidades.Comic oc)
        {

            BDComicsDataContext DB = null;
            try
            {
                
                using (DB = new BDComicsDataContext())
                {
                    
                    DB.CP_ModificarComic(oc.Id,oc.Nombre, oc.Id_serie, oc.Id_genero, oc.Id_autor, oc.Id_editorial,oc.Descripcion,oc.Precio, oc.Stock, oc.Imagen);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla Comic", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarComic(Entidades.Comic oc)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_EliminarComic(oc.Id);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar un registro de la tabla Comic", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
