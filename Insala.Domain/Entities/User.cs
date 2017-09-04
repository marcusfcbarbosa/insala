using Insala.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.DDD;

namespace Insala.Domain.Entities
{

    public class User : Entity
    {
        [Key]
        public Guid Id { get; set; }

        public string Picture { get; set; }

        public UserType Type { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Boolean isActive { get; set; }

    }
}
