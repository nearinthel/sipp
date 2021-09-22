using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class Usuario
    {

        public DTOs.DTOUsuario getDT()
        {
            DTOs.DTOUsuario dt = new DTOs.DTOUsuario();
            dt.Id = this.Id;
            dt.Nombre = this.Nombre;
            dt.Apellido = this.Apellido;
            dt.Telefono = this.Telefono;
            dt.Celular = this.Celular;
            dt.Email = this.Email;
            dt.Pass = this.Pass;
            return dt;
        }

        public Usuario(long id, string nombre, string apellido, string celular, string telefono, string email, string pass)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Celular = celular;
            this.Email = email;
            this.Pass = pass;
        }

        public Usuario(DTOs.DTOUsuario dto)
        {
            this.Id = dto.Id;
            this.Nombre = dto.Nombre;
            this.Apellido = dto.Apellido;
            this.Telefono = dto.Telefono;
            this.Celular = dto.Celular;
            this.Email = dto.Email;
            this.Pass = dto.Pass;

            List<Ubicacion> listUbicaciones = new List<Ubicacion>();


            if (dto.Ubicacion != null)
            {
                foreach (DTOs.DTOUbicacion dtoUbi in dto.Ubicacion)
                {
                    listUbicaciones.Add(new Ubicacion(dtoUbi));
                }
            }

            this.Ubicacion = listUbicaciones;
        }
    }
}
