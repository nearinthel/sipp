using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Data.Entity;
using System.Transactions;

namespace RemoteControllers
{
    public class ControladorPedido
    {

        private static ControladorPedido instance;

        private ControladorPedido() { }

        public static ControladorPedido Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ControladorPedido();
                }
                return instance;
            }
        }

        public static List<Pedido> getPedidos()
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    List<Pedido> lstDir = contexto.Pedido.Select(p => p).ToList();
                    return lstDir;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Pedido ObtenerPedido(long id)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {


                    Pedido pedido = contexto.Pedido.FirstOrDefault(usr => usr.Id == id);
                    if (pedido != null)
                        return pedido;
                    else
                        return new Pedido(0,false,0,0,"","","","","","");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool guardarPedido(Pedido p)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    Pedido pedido = contexto.Pedido.FirstOrDefault(ped => ped.Id == p.Id);

                    //p.Id = pedido.Id;
                    //pedido = p;
                    contexto.Entry(pedido).CurrentValues.SetValues(p);
                    int result = contexto.SaveChanges();
                    bool retorno = false;
                    if (result > 0)
                    {
                        retorno = true;
                    }

                    return retorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static Pedido ingresarPedido(Pedido p)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    Pedido pedResult = contexto.Pedido.Add(p);
                    int result = contexto.SaveChanges();

                    if (result > 0)
                    {
                        return p;
                    }

                    else
                        return new Pedido(0, false, 0, 0, "", "", "", "", "", "");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
