using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Entities
{
    public partial class Estado
    {
        public DTOEstado getDTO()
        {
            DTOEstado state = new DTOEstado();
            state.IdEstado = this.IdEstado;
            state.FechaEnviado = this.FechaEnviado;
            state.FechaPedido = this.FechaPedido;
            state.FechaProceso = this.FechaProceso;
            state.IdPedido = this.IdPedido;
            state.TipoEstado = this.TipoEstado;
            return state;
        }

        public Estado(DTOEstado state)
        {
            this.FechaEnviado = state.FechaEnviado;
            this.FechaPedido = state.FechaPedido;
            this.FechaProceso = state.FechaProceso;
            this.IdEstado = state.IdEstado;
            this.IdPedido = state.IdPedido;
            this.TipoEstado = state.TipoEstado;
        }
        public Estado()
        {
        }
    }
}
