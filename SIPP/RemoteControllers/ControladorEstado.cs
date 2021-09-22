using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace RemoteControllers
{
    public class ControladorEstado:ControladorHerenciable
    {
         private static ControladorEstado instance;

        private ControladorEstado()
        {
        }

        public static ControladorEstado getInstance()
        {
            if (instance == null)
            {
                instance = new ControladorEstado();
            }
            return instance;
        }

        public bool newEstado(Estado newState) 
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Estado state = new Estado();
                state.TipoEstado = newState.TipoEstado;
                state.IdPedido = newState.IdPedido;
                if (newState.FechaEnviado == null)
                {
                    state.FechaEnviado = newState.FechaEnviado;
                }
                else
                {
                    state.FechaEnviado = DateTime.Now.ToString("yyyy/MM/dd mm:HH");
                }
                state.FechaPedido = newState.FechaPedido;
                state.FechaProceso = newState.FechaProceso;
                state.IdEstado = handler.Estado.Max(es=>es.IdEstado) + 1;
                handler.Estado.Add(state);
                return this.salvar(handler);

            }
        }

        public bool modifyEstado(Estado state)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Estado modState = handler.Estado.FirstOrDefault(sta => sta.IdEstado==state.IdEstado);
                if (state.TipoEstado == 1)
                {
                    state.FechaProceso = DateTime.Now.ToString("yyyy/MM/dd mm:HH");
                }
                if (state.TipoEstado == 2)
                {
                    if (state.FechaProceso == "")
                    {
                        state.FechaProceso = DateTime.Now.ToString("yyyy/MM/dd mm:HH");
                    }
                    state.FechaEnviado = DateTime.Now.ToString("yyyy/MM/dd mm:HH");
                }
                handler.Entry(modState).CurrentValues.SetValues(state);
                return this.salvar(handler);
            }
        }

        public bool removeEstado(Estado state)
        {
            using(AlacartaEntities handler=new AlacartaEntities())
            {
                handler.Estado.Remove(state);
                return this.salvar(handler);

            }
        }

        public Estado getEstado(long id)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Estado state = handler.Estado.FirstOrDefault(sta => sta.IdEstado == id);
                return state;
            }
        }


        public Estado getEstadoPorPedido(long idPedido)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Estado state = handler.Estado.FirstOrDefault(sta => sta.IdPedido == idPedido);
                return state;
            }
        }
    }
}
