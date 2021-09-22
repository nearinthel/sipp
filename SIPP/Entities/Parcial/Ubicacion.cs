using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
        }
        public DTOs.DTOUbicacion getDT()
        {
            DTOs.DTOUbicacion dt = new DTOs.DTOUbicacion();
            dt.Nombre_referencia = this.Nombre_referencia;
            dt.Id_usuario = this.Id_usuario;
            dt.Direccion = this.Direccion;
            dt.Latitud = this.Latitud;
            dt.Longitud = this.Longitud;
            return dt;
        }

        public Ubicacion(string nombre_referencia, string latitud, string longitud, string direccion, long id_usuario)
        {
            this.Nombre_referencia = nombre_referencia;
            this.Latitud = latitud;
            this.Longitud = longitud;
            this.Direccion = direccion;
            this.Id_usuario = id_usuario;
        }

        public Ubicacion(DTOs.DTOUbicacion dto)
        {
            this.Nombre_referencia = dto.Nombre_referencia;
            this.Latitud = dto.Latitud;
            this.Longitud = dto.Longitud;
            this.Direccion = dto.Direccion;
            this.Id_usuario = dto.Id_usuario;
        }
    }

}
