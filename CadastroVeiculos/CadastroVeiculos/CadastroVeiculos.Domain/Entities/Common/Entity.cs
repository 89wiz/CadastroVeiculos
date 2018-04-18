using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroVeiculos.Domain.Entities.Common
{
    public class Entity
    {
        public Guid ID { get; set; }

        public virtual void GenerateGuid()
        {
            ID = Guid.NewGuid();
        }

        public virtual void UpdateGuid()
        {
            if (ID.Equals(Guid.Empty)) ID = Guid.NewGuid();
        }
    }
}
