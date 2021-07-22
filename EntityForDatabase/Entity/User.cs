using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityForDatabase.Entity
{
    public class User : IBaseEntity
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime OrderTime { get; set; }
        public uint NumberEmailSent { get; set; }

    }
}
