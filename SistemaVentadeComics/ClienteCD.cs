using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentadeComics
{
    public class ClienteCD
    {
        public static List<CP_ListarClienteFiltroResult> ListarClienteFiltro(string val)
        {
            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    return DB.CP_ListarClienteFiltro(val).ToList();
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

        public static void InsertarCliente(Entidades.Cliente oc)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_InsertarCliente(oc.Nombre, oc.Apellido, oc.Sexo,oc.Cedula, oc.Fecha,oc.Direccion,oc.Telefono,oc.Correo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarCliente(Entidades.Cliente oc)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {

                    DB.CP_ModificarCliente(oc.Id,oc.Nombre, oc.Apellido, oc.Sexo,oc.Cedula, oc.Fecha, oc.Direccion, oc.Telefono, oc.Correo);
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

        public static void EliminarCliente(Entidades.Cliente oc)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_EliminarCliente(oc.Id);
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
