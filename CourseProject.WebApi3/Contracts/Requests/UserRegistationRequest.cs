using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.WebApi3.Contracts.Requests
{
    public class UserRegistationRequest
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// User Name.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Password Confirm.
        /// </summary>
        [Required]
        public string PasswordConfirm { get; set; }


    }
}
