using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class Especificacion
    {
        //public Especificacion()
        //{
        //}

        public DTOs.DTOEspecificacion getDT()
        {
            DTOs.DTOEspecificacion dt = new DTOs.DTOEspecificacion();
            dt.id = this.id;
            dt.Nombre = this.Nombre;
            dt.Descripcion = this.Descripcion;
            return dt;
        }

        public Especificacion(long id, string nombre, decimal costo, string descripcion)
        {
            this.id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public Especificacion(DTOs.DTOEspecificacion dto)
        {
            this.id = dto.id;
            this.Nombre = dto.Nombre;
            this.Descripcion = dto.Descripcion;
        }
    }
}
