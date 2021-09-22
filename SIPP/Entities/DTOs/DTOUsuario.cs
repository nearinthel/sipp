using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Entities.DTOs
{
    [DataContract]
    public class DTOUsuario
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Pass { get; set; }

        [DataMember]
        public virtual ICollection<DTOUbicacion> Ubicacion { get; set; }
    }

}
