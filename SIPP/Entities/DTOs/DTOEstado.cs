using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Entities.DTOs
{
    [DataContract]
     public class DTOEstado
    {
        [DataMember]
        public long IdEstado { get; set; }
        [DataMember]
        public long TipoEstado { get; set; }
        [DataMember]
        public string FechaPedido { get; set; }
        [DataMember]
        public string FechaProceso { get; set; }
        [DataMember]
        public string FechaEnviado { get; set; }
        [DataMember]
        public long IdPedido { get; set; }
    }
}
