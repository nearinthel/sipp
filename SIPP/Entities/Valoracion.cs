//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Valoracion
    {
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public long id_usuario { get; set; }
        [DataMember]
        public long id_empresa { get; set; }
        [DataMember]
        public int puntaje { get; set; }
        [DataMember]
        public string comentario { get; set; }
        [DataMember]
        public System.DateTime fecha { get; set; }
    [DataMember]
        public virtual Empresa Empresa { get; set; }
        [DataMember]
        public virtual Usuario Usuario { get; set; }
    }
}