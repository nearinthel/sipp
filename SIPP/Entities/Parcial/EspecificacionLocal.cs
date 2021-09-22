using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Entities
{
    public partial class EspecificacionLocal
    {
        public DTOEspecificacionLocal getDTO()
        {
            DTOEspecificacionLocal item = new DTOEspecificacionLocal();
            item.id = this.id;
            item.idEspecificacion = this.idEspecificacion;
            item.idLocal = this.idLocal;
            item.costo = this.costo;

            item.Especificacion = this.Especificacion.getDT();
            item.Local = this.Local.getDTO();
            return item;
        }

        public EspecificacionLocal(DTOEspecificacionLocal item)
        {
            this.id = item.id;
            this.idEspecificacion = item.idEspecificacion;
            this.idLocal = item.idLocal;
            this.costo = item.costo;

            this.Especificacion = new Especificacion(item.Especificacion);
            this.Local = new Local(item.Local);
        }

        public EspecificacionLocal()
        {
        }
    }
}
