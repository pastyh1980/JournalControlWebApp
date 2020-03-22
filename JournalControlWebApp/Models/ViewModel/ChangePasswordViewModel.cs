using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JournalControlWebApp.Models.ViewModel
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Подтверждение пароля")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ValidatePassword { get; set; }

        public string ReturnURL { get; set; }
    }
}
