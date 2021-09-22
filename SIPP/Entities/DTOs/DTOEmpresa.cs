using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Entities.DTOs
{
    [DataContract]
    public class DTOEmpresa
    {
        [DataMember]
        public long Rut{get;set;}
        [DataMember]
        public string RazonSocial{get;set;}

        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Pass { get; set; }
        //public ICollection


    }
}
