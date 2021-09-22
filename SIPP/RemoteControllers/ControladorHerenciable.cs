using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteControllers.Exceptions;
using Entities;
using DAL;
//using System.Data.Entity.Validation;

namespace RemoteControllers
{
    public class ControladorHerenciable
    {
        protected bool salvar(AlacartaEntities handler)
        {
       
                bool salvado = false;

                int resultado = handler.SaveChanges();
                if (resultado > 0)
                {
                    //throw new NoSalvadoException();
                    salvado = true;

                }
              
                return salvado;
        
        }

       
	   
    //    public bool salvar(AlacartaEntities context)
    //    {
    //        try
    //        {
    //            return this.save(context);
    //            //context.SaveChanges();
    //        }
    //        catch (DbEntityValidationException ex)
    //        {
    //            StringBuilder sb = new StringBuilder();

    //            foreach (var failure in ex.EntityValidationErrors)
    //            {
    //                sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
    //                foreach (var error in failure.ValidationErrors)
    //                {
    //                    sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
    //                    sb.AppendLine();
    //                }
    //            }

    //            throw new DbEntityValidationException(
    //                "Entity Validation Failed - errors follow:\n" +
    //                sb.ToString(), ex
    //            ); // Add the original exception as the innerException
    //        }
    //    }


    }
    
}
