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
    
    public partial class EspecificacionLocal
    {
        public long id { get; set; }
        public long idEspecificacion { get; set; }
        public string idLocal { get; set; }
        public decimal costo { get; set; }
    
        public virtual Especificacion Especificacion { get; set; }
        public virtual Local Local { get; set; }
    }
}
