using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Mvc.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        [Required]
        [Display(Name = "Год рождения")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[Display(Name = "Login")]
        //public string Login { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Пароль")]
        //public string Password { get; set; }

        //[Required]
        //[Compare("Password", ErrorMessage = "Пароли не совпадают")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Подтвердить пароль")]
        //public string PasswordConfirm { get; set; }

        //[Required]
        //[Display(Name = "Email")]
        //public string Email { get; set; }

        //[Required]
        //[Display(Name = "Пол")]
        //public string Gender { get; set; }

        //[Required]
        //[Display(Name = "Год рождения")]
        //public int Year { get; set; }

        //[Required]
        //[Display(Name = "Дата рождения")]
        //public DateTime Birthday { get; set; }
    }
}
