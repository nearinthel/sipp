using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Entities
{
    public partial class Articulo
    {
        public DTOArticulo getDTO()
        {
            DTOArticulo item = new DTOArticulo();
            item.Descripcion = this.Descripcion;
            item.Nombre = this.Nombre;
            item.Unidad_base = this.Unidad_base;
            return item;
        }

        public Articulo(DTOArticulo item)
        {
           
            this.Descripcion = item.Descripcion;
            this.Nombre = item.Nombre;
            this.Unidad_base = item.Unidad_base;
        }

        //public Articulo()
        //{
        //}
    }
}
