using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    [DataContract]
    public class DTOPedido
    {
        [DataMember]
        public decimal Costo { get; set; }
        [DataMember]
        public bool Estado { get; set; }
        [DataMember]
        public long Id_usuario { get; set; }
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Nombre_Local { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Codigo_html { get; set; }
        [DataMember]
        public string DireccionPedido { get; set; }
        [DataMember]
        public string LatitudDireccion { get; set; }
        [DataMember]
        public string LongitudDireccion { get; set; }
    }









}