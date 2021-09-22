using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Entities
{
    public partial class Local
    {
        public DTOLocal getDTO()
        {
            DTOLocal sucursal=new DTOLocal();
            sucursal.Direccion=this.Direccion;
            sucursal.Latitud=this.Latitud;
            sucursal.Longitud=this.Longitud;
            sucursal.Nombre=this.Nombre;
            sucursal.Pass = this.Pass;
            sucursal.Rut_empresa=this.Rut_empresa;
            sucursal.Telefono=this.Telefono;
            sucursal.Area = this.Area;
            sucursal.Localidad = this.Localidad;
            //if (this.Articulo != null)
            //{
            //    foreach (Articulo item in this.Articulo)
            //    {
            //        //sucursal.Articulo.Add(item.getDTO());

            //    }
            //}

            return sucursal;
        }

        public Local(DTOLocal sucursal)
        {
            this.Area = sucursal.Area;
            this.Direccion = sucursal.Direccion;
            this.Pass = sucursal.Pass;
            this.Latitud = sucursal.Latitud;
            this.Longitud = sucursal.Longitud;
            this.Nombre = sucursal.Nombre;
            this.Rut_empresa = sucursal.Rut_empresa;
            this.Telefono = sucursal.Telefono;
            this.Localidad = sucursal.Localidad;
            //if (sucursal.Articulo != null)
            //{
            //    foreach (DTOArticulo item in sucursal.Articulo)
            //    {
            //        this.Articulo.Add(new Articulo(item));
            //    }
            //}
        }
    }
}
