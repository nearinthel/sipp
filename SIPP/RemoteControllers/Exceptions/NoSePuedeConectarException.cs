using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControllers.Exceptions
{
    public class NoSePuedeConectarException:Exception
    {
        const string msjAuxiliar = "Combinacion erronea de Usuario y Contraseña";
           public NoSePuedeConectarException():base(msjAuxiliar)
            {
                
            }
    }
}
