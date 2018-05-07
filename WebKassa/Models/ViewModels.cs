using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebKassa.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Введите логин")]
        [Display(Name ="Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}