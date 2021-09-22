using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Entities.DTOs
{
    [DataContract]
    public class DTOArticulo
    {
        [DataMember]
        public string Nombre { get; set; }

        //descripcion??
        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public decimal Unidad_base { get; set; }
    }
}
