using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Entities
{
    public partial class Empresa
    {
        public Empresa(DTOEmpresa enterprise)
        {
            //this.Logo = enterprise.Logo;
            this.Pass = enterprise.Pass;
            this.Razon_social = enterprise.RazonSocial;
            this.Rut = enterprise.Rut;
            this.Telefono = enterprise.Telefono;
        }
        public DTOEmpresa getDTO()
        {
            DTOEmpresa dto = new DTOEmpresa();
           // dto.Logo = this.Logo;
            dto.Pass = this.Pass;
            dto.RazonSocial = this.Razon_social;
            dto.Rut = this.Rut;
            dto.Telefono = this.Telefono;
            return dto;
        }
    }
}
