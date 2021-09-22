using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControllers.Exceptions
{
    public class ObjetoNoExisteException:Exception
    {
        const string msjAuxiliar="No se pudo encontrar";
        public ObjetoNoExisteException(string auxMsj):base(String.Format("{0} - {1}",msjAuxiliar, auxMsj))
        {
        }
    }
}
