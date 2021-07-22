using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopPakemon.Models.ModelForUser
{
    public class ViewModelForUser
    {
        [Required(ErrorMessage = "Заполните поле")]     
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Емаил не валиден")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Номер не валиден")]
        public string Phone { get; set; }
    }
}
