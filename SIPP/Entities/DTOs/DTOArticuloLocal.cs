using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Entities.DTOs
{
    [DataContract]
    public class DTOArticuloLocal
    {
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public string idArticulo { get; set; }
        [DataMember]
        public string idLocal { get; set; }

        //articulo-local
        [DataMember]
        public Nullable<decimal> Costo_base { get; set; }
        [DataMember]
        public virtual DTOArticulo Articulo { get; set; }
        [DataMember]
        public virtual DTOLocal Local { get; set; }
    }
}
