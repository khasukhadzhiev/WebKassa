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
    public class KassaModel
    {
        public int ID { get; set; }
        public short? RIS_ACTIVE { get; set; }
        public string RNAME { get; set; }
        public string RTARIFSTR { get; set; }
        public decimal? BALANCE { get; set; }
        public string RSUPPLIER_NAME { get; set; }
    }
}