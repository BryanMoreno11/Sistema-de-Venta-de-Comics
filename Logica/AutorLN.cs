using SistemaVentadeComics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class AutorLN
    {
        public List<Entidades.Autor> ViewAutorFiltro(string valor, string tipo)
        {
            byte[] imagen = null;
            List<Entidades.Autor> lista = new List<Entidades.Autor>();
            Entidades.Autor oa;

            try
            {
                List<CP_ListarAutorFiltroResult> auxLista = AutorCD.ListarAutorFiltro(valor);
                foreach (CP_ListarAutorFiltroResult obj in auxLista)
                {
                    imagen = null;

                    if (obj.imagen != null)
                    {

                        imagen = obj.imagen.ToArray();
                        if (tipo.Equals("Miniatura"))
                        {
                            Image originalImage = Image.FromStream(new MemoryStream(imagen));
                            Image thumbnailImage = originalImage.GetThumbnailImage(150, 150, null, IntPtr.Zero);
                            imagen = imageToByteArray(thumbnailImage);
                        }
                    }
                    oa = new Entidades.Autor(obj.id, obj.nombre, obj.apellido,obj.descripcion, imagen);
                    lista.Add(oa);
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
        public bool CreateAutor(Entidades.Autor oa)
        {

            try
            {
                AutorCD.InsertarAutor(oa);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar autor en la BD");
            }
        }

        public bool UpdateAutor(Entidades.Autor oa)
        {

            try
            {
                AutorCD.ModificarAutor(oa);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al modificar autor en la BD");
            }
        }

        public bool DeleteAutor(Entidades.Autor oa)
        {

            try
            {
                AutorCD.EliminarAutor(oa);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar autor en la BD");
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}
