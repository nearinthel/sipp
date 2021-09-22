using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Entities.DTOs
{
    [DataContract]
    public class DTOEspecificacionLocal
    {
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public long idEspecificacion { get; set; }
        [DataMember]
        public string idLocal { get; set; }

        //articulo-local
        [DataMember]
        public decimal costo { get; set; }
        [DataMember]
        public virtual DTOEspecificacion Especificacion { get; set; }
        [DataMember]
        public virtual DTOLocal Local { get; set; }
    }
}
