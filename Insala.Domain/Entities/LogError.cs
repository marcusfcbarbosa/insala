using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.DDD;

namespace Insala.Domain.Entities
{
    public class LogError : Entity
    {
        [Key]
        public Guid Id { get; set; }

        public String EntityReference { get; private set; }

        public String Error { get; private set; }

        public LogError(String entityReference, String error)
        {
            this.EntityReference = entityReference;
            this.Error = error;
        }

    }
}
