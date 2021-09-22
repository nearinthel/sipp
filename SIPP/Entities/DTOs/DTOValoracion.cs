using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    
 
    [DataContract]
    public class  DTOValoracion

    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long IdUsuario { get; set; }
        [DataMember]
        public long IdEmpresa{ get; set; }
        [DataMember]
        public int Puntaje { get; set; }
        [DataMember]
        public string Comentario { get; set; }
        [DataMember]
        public System.DateTime Fecha { get; set; }
        
    }
}
