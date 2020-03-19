using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JournalControlWebApp.Models.ViewModel
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Family { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        public string Otch { get; set; }

        [Required]
        [Display(Name = "Должность")]
        public string Post { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
