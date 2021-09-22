using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Entities
{
    public partial class ArticuloLocal
    {
        public DTOArticuloLocal getDTO()
        {
            DTOArticuloLocal item = new DTOArticuloLocal();
            item.id = this.id;
            item.idArticulo = this.idArticulo;
            item.idLocal = this.idLocal;
            item.Costo_base = this.Costo_base;

            item.Articulo = this.Articulo.getDTO();
            item.Local = this.Local.getDTO();
            return item;
        }

        public ArticuloLocal(DTOArticuloLocal item)
        {
            this.id = item.id;
            this.idArticulo = item.idArticulo;
            this.idLocal = item.idLocal;
            this.Costo_base = item.Costo_base;

            this.Articulo = new Articulo(item.Articulo);
            this.Local = new Local(item.Local);
        }

        public ArticuloLocal()
        {
        }
    }
}
