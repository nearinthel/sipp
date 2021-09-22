using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities{

    public partial class Valoracion
    {
        public Valoracion()
        {
        }
        
    
    public  Entities.DTOs.DTOValoracion getDT()
        {
            DTOs.DTOValoracion dt = new DTOs.DTOValoracion();
            dt.Id = this.id;
            dt.IdUsuario = this.id_usuario;
            dt.IdEmpresa = this.id_empresa;
            dt.Puntaje = this.puntaje;
            dt.Comentario = this.comentario;
            dt.Fecha = this.fecha;
            
            return dt;
        }

        

        public Valoracion(DTOs.DTOValoracion dto)
        {
           this.id = dto.Id;
           this.id_usuario = dto.IdUsuario;
           this.id_empresa = dto.IdEmpresa;
           this.puntaje = dto.Puntaje;
           this.comentario = dto.Comentario;
            this.fecha = dto.Fecha;

            
        }

        
    }
     
}
