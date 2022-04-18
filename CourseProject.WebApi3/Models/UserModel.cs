﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.WebApi3.Models
{
    /// <summary>
    /// User model.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Fullname.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
    }
}
