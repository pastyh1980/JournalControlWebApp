using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using JournalControlWebApp.Models.dbo;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ValidatePassword { get; set; }

        [Required]
        [Display(Name = "Подразделение")]
        public int Subunit { get; set; }

        [Required]
        [Display(Name = "Участок")]
        public int Sector { get; set; }

        public SelectList Subunits { get; set; }

        public List<Sector> Sectors { get; set; }

        [Display(Name = "Роли")]
        public List<Role> AllRoles { get; set; }

        public CreateUserViewModel() { }

        public CreateUserViewModel(journalContext context)
        {
            FillLists(context);
        }

        public void FillLists(journalContext context)
        {
            Subunits = new SelectList(context.Subunits.ToList(), "Id", "Name");
            Sectors = context.Sectors.ToList();
        }
    }
}
