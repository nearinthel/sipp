using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControllers.Exceptions

{
    
        public class NoSalvadoException : Exception
        {
            const string msjAuxiliar="No se pudo Salvar";

            public NoSalvadoException():base(msjAuxiliar)
            {
                
            }
        }
    
}
