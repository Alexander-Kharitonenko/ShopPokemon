using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopPakemon.Models.ModelForUser
{
    public class ViewModelForAllUser
    {
        public IEnumerable<UserDTO> AllUser { get; set; }
    }
}
