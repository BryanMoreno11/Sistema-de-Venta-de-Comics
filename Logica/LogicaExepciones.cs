using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaExepciones:ApplicationException
    {
        public LogicaExepciones(string mensaje, Exception ex)
       : base(mensaje, ex)
        {

        }
        public LogicaExepciones(string mensaje)
       : base(mensaje)
        {

        }
    }
}
