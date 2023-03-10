using SistemaVentadeComics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace Logica
{
    public class SerieLN
    {
        public List<Entidades.Serie> ViewSerieFiltro(string valor, string tipo)
        {
            byte[] imagen= null;   
            List<Entidades.Serie> lista = new List<Entidades.Serie>();
            Entidades.Serie os;

            try
            {
                List<CP_ListarSerieFiltroResult> auxLista = SerieCD.ListarSerieFiltro(valor);
                foreach (CP_ListarSerieFiltroResult obj in auxLista)
                {
                    imagen = null;
                    if (obj.imagen != null)
                    {
                       
                        imagen = obj.imagen.ToArray();
                        if (tipo.Equals("Miniatura"))
                        {
                            Image originalImage = Image.FromStream(new MemoryStream(imagen));
                            Image thumbnailImage = originalImage.GetThumbnailImage(100, 150, null, IntPtr.Zero);
                            imagen = imageToByteArray(thumbnailImage);
                        }
                    } 
                    os = new Entidades.Serie(obj.id,obj.nombre,obj.descripcion,imagen);
                    lista.Add(os);
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
        public bool CreateSerie(Entidades.Serie os)
        {

            try
            {
                SerieCD.InsertarSerie(os);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar serie en la BD");
            }
        }

        public bool UpdateSerie(Entidades.Serie os)
        {

            try
            {
                SerieCD.ModificarSerie(os);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al modificar serie en la BD");
            }
        }

        public bool DeleteSerie(Entidades.Serie os)
        {

            try
            {
                SerieCD.EliminarSerie(os);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar actor en la BD");
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
