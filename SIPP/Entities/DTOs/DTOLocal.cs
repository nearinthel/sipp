using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Entities.DTOs
{
    [DataContract]
    public class DTOLocal
    {
        [DataMember]
        public Nullable<decimal> Area { get; set; }
        [DataMember]
        public string Localidad { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Latitud { get; set; }
        [DataMember]
        public string Longitud { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public decimal Telefono { get; set; }
        [DataMember]
        public long Rut_empresa { get; set; }
        [DataMember]
        public string Pass { get; set; }
        [DataMember]
        public virtual ICollection<DTOArticulo> Articulo { get; set; }
        //public virtual Empresa Empresa { get; set; }
        //public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
