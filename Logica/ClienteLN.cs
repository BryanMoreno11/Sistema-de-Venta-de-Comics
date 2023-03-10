using SistemaVentadeComics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ClienteLN
    {
        public List<Entidades.Cliente> ViewClienteFiltro(string valor)
        {
            List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
            Entidades.Cliente oc;

            try
            {
                List<CP_ListarClienteFiltroResult> auxLista = ClienteCD.ListarClienteFiltro(valor);
                foreach (CP_ListarClienteFiltroResult obj in auxLista)
                {
                    oc = new Entidades.Cliente(obj.id, obj.nombre, obj.apellido, obj.sexo,obj.cedula, obj.fecha_nacimiento, obj.direccion, obj.telefono, obj.correo);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al mostar serie con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }
        public bool CreateCliente(Entidades.Cliente oc)
        {

            try
            {
                ClienteCD.InsertarCliente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar autor en la BD");
            }
        }

        public bool UpdateCliente(Entidades.Cliente oc)
        {

            try
            {
                ClienteCD.ModificarCliente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al modificar autor en la BD");
            }
        }

        public bool DeleteCliente(Entidades.Cliente oc)
        {

            try
            {
                ClienteCD.EliminarCliente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar autor en la BD");
            }
        }
    }
}
