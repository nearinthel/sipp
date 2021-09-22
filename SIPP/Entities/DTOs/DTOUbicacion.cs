using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Entities.DTOs
{
    [DataContract]
    public class DTOUbicacion
    {
        [DataMember]
        public string Nombre_referencia { get; set; }
        [DataMember]
        public string Latitud { get; set; }
        [DataMember]
        public string Longitud { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public long Id_usuario { get; set; }
    }
}
